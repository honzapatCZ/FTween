using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public class Sequence : FTweener
    {
        public Sequence() : base(0){
            
        }

        public override FTweener Reverse()
        {
            Debug.LogWarning("You cant reverse a sequence");
            return this;
        }

        internal override void SetupSpeedBased()
        {
            Debug.LogWarning("Sequence cant be speedBased");
        }

        public class SeqTween
        {
            public float time;
            public FTweener tween;
            public SeqTween(float time, FTweener tween)
            {
                this.time = time;
                this.tween = tween;
            }
        }

        List<SeqTween> tweens = new List<SeqTween>();

        float lastTweenInsertTime;
        public Sequence Append(FTweener tween)
        {
            return Insert(tween, duration);
        }
        public Sequence Insert(FTweener tween)
        {
            return Insert(tween, lastTweenInsertTime);
        }
        public Sequence Insert(FTweener tween, float time)
        {
            if(tween.loops != 0)
            {
                Debug.LogWarning("You cant have loop tween in sequence, setting tween loops to 0");
                tween.loops = 0;
            }
            duration = Mathf.Max(duration, time + (tween.duration * tween.timeScale * timeScale) + tween.startDelay);
            lastTweenInsertTime = time;
            tween.parentSeq = this;

            tweens.Add(new SeqTween(time, tween));
            return this;
        }

        public Sequence AppendCallback(Action onDone)
        {
            return Append(new FCallback(onDone));
        }
        public Sequence InsertCallback(Action onDone)
        {
            return Insert(new FCallback(onDone));
        }
        public Sequence InsertCallback(Action onDone, float time)
        {
            return Insert(new FCallback(onDone), time);
        }

        public override void ResetCurrentLoop()
        {
            base.ResetCurrentLoop();
            foreach (SeqTween seqTween in tweens)
            {
                seqTween.tween.Reset();
            }
        }

        internal override void update(float delta)
        {
            timeFromStart += delta * timeScale;

            float relativeTime = timeFromStart - startDelay;
            if (relativeTime > 0 && !isComplete)
            {
                foreach (SeqTween seqTween in tweens)
                {
                    if(relativeTime > seqTween.time)
                    {
                        if (!seqTween.tween.setup)
                            seqTween.tween.Setup();

                        seqTween.tween.update(delta * timeScale);
                    }
                }
            }
            if (relativeTime >= duration && !isComplete)
            {
                if (loops != 0)
                {
                    loops--;
                    try
                    {
                        onLoopComplete?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error has been thrown during invoke of onLoopComplete of tween: " + e.Message);
                        Debug.Log(e.StackTrace);
                    }
                    ResetCurrentLoop();
                }
                else
                {
                    try
                    {
                        onComplete?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error has been thrown during invoke of onComplete of tween: " + e.Message);
                        Debug.Log(e.StackTrace);
                    }
                    _isComplete = true;
                    if (parentSeq == null)
                        Kill();
                }
            }
        }
    }
}
