using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FlaxEngine;

namespace FTween
{
    public delegate T FGetter<out T>();
    public delegate void FSetter<in T>(T newValue);

    public abstract class FTweener
    {
        internal float duration;

        public float timeScale = 1;

        public Sequence parentSeq;

        public FTweener(float time)
        {
            this.duration = time;
        }

        internal bool setup;
        internal virtual void Setup()
        {
            if (setup)
                Debug.LogWarning("Tried to setup again");
            setup = true;

            InnerSetup();

            if (speedBased)
                SetupSpeedBased();
        }
        internal virtual void InnerSetup() { }

        internal bool speedBased;
        public FTweener SetSpeedBased(bool val)
        {
            if (setup) Debug.LogWarning("Tried to modify running tween");
            
            speedBased = val;
            return this;
        }
        internal float startDelay = 0;
        public FTweener SetDelay(float val)
        {
            if (setup) Debug.LogWarning("Tried to modify running tween");

            startDelay = val;
            return this;
        }

        internal Ease ease;
        internal EaseDelegate customEase;
        public FTweener SetEase(Ease ease)
        {
            if (setup) Debug.LogWarning("Tried to modify running tween");

            this.ease = ease;
            return this;
        }
        public FTweener SetEase(EaseDelegate ease)
        {
            if (setup) Debug.LogWarning("Tried to modify running tween");

            this.ease = Ease.__Custom;
            customEase = ease;
            return this;
        }

        public abstract FTweener Reverse();

        internal bool _isComplete;
        public bool isComplete
        {
            get
            {
                return _isComplete;
            }
                
        }

        internal Action onComplete;
        public FTweener OnComplete(Action onComplete)
        {
            this.onComplete += onComplete;
            return this;
        }

        internal Action onLoopComplete;
        public FTweener OnLoopComplete(Action onLoopComplete)
        {
            this.onLoopComplete += onLoopComplete;
            return this;
        }

        internal int loops = 0;
        public FTweener SetLoops(int loops)
        {
            if (setup) Debug.LogWarning("Tried to modify running tween");

            this.loops = loops;
            return this;
        }

        public virtual void ResetCurrentLoop()
        {
            timeFromStart = 0;
        }
        public virtual void Reset()
        {
            ResetCurrentLoop();
            _isComplete = false;
        }

        internal float timeFromStart = 0;

        internal abstract void update(float delta);
        internal abstract void SetupSpeedBased();
                
        public FTweener Start()
        {
            FTweenScene.AddTween(this);
            return this;
        }
        public void Kill()
        {
            FTweenScene.RemoveTween(this);
            GC.SuppressFinalize(this);
        }

        public FTWeenerAwaiter GetAwaiter()
        {
            return new FTWeenerAwaiter(this);
        }
    }
    public class FTWeenerAwaiter : INotifyCompletion
    {
        public FTweener tween;
        public FTWeenerAwaiter(FTweener tween)
        {
            this.tween = tween;
        }
        public bool IsCompleted
        {
            get
            {
                return tween.isComplete;
            }
        }
        public void OnCompleted(Action continuation)
        {
            tween.OnComplete(continuation);
        }
        public void GetResult(){}
    }

    public abstract class FTweener<T1> : FTweener where T1: struct
    {
        internal FGetter<T1> getter;
        internal FSetter<T1> setter;
        internal T1 startValue;
        internal T1 endValue;
        internal T1 difference;

        public FTweener(FGetter<T1> getter, FSetter<T1> setter, T1 end, float time) : base(time)
        {
            this.getter = getter;
            this.setter = setter;
            this.endValue = end;
        }

        internal override void InnerSetup()
        {
            base.InnerSetup();
            this.startValue = getter();
            this.difference = GetDifference();
        }

        public override void Reset()
        {
            base.Reset();
            setter(startValue);
        }

        public virtual FTweener From(T1 theVal)
        {
            endValue = startValue;
            startValue = theVal;

            difference = GetDifference();
            return this;
        }

        public override FTweener Reverse()
        {
            T1 prevEnd = endValue;
            endValue = startValue;
            startValue = prevEnd;

            difference = GetDifference();
            return this;
        }
        internal override void update(float delta)
        {
            timeFromStart += delta*timeScale;
            float relativeTime = timeFromStart - startDelay;
            if (relativeTime > 0 && !isComplete)
            {
                float percentage = relativeTime / duration;

                SetValueByNormal(EaseFunc.Evaluate(percentage, ease, customEase));
            }
            if(relativeTime >= duration && !isComplete)
            {
                if(loops != 0)
                {
                    loops--;
                    onLoopComplete?.Invoke();
                    ResetCurrentLoop();
                }
                else
                {
                    onComplete?.Invoke();
                    _isComplete = true;
                    if(parentSeq == null)
                        Kill();
                }
            }
        }
        internal override void SetupSpeedBased()
        {
            duration = GetDurationIfSpeedBased();
        }
        internal abstract T1 GetDifference();
        internal abstract float GetDurationIfSpeedBased();

        internal abstract void SetValueByNormal(float normal);
    }

    public class FloatFTweener : FTweener<float>
    {
        public FloatFTweener(FGetter<float> getter, FSetter<float> setter, float end, float time) : base(getter, setter, end, time){}

        internal override float GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return difference / duration;
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue+(endValue-startValue)*normal);
        }
    }

    public class ColorFTweener : FTweener<Color>
    {
        public ColorFTweener(FGetter<Color> getter, FSetter<Color> setter, Color end, float time) : base(getter, setter, end, time) { }

        internal override Color GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return (1 / duration);
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue + difference * normal);
        }
    }

    public class Vector4FTweener : FTweener<Vector4>
    {
        public Vector4FTweener(FGetter<Vector4> getter, FSetter<Vector4> setter, Vector4 end, float time) : base(getter, setter, end, time){}

        internal override Vector4 GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return difference.Length / duration;
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue + difference * normal);
        }
    }
    public class Vector3FTweener : FTweener<Vector3>
    {
        public Vector3FTweener(FGetter<Vector3> getter, FSetter<Vector3> setter, Vector3 end, float time) : base(getter, setter, end, time) { }

        internal override Vector3 GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return difference.Length / duration;
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue + difference * normal);
        }
    }
    public class Vector2FTweener : FTweener<Vector2>
    {
        public Vector2FTweener(FGetter<Vector2> getter, FSetter<Vector2> setter, Vector2 end, float time) : base(getter, setter, end, time) { }

        internal override Vector2 GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return difference.Length / duration;
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue + difference * normal);
        }
    }
    public class QuaternionFTweener : FTweener<Quaternion>
    {
        public QuaternionFTweener(FGetter<Quaternion> getter, FSetter<Quaternion> setter, Quaternion end, float time) : base(getter, setter, end, time) { }

        internal override Quaternion GetDifference()
        {
            return endValue - startValue;
        }

        internal override float GetDurationIfSpeedBased()
        {
            return difference.Length / duration;
        }

        internal override void SetValueByNormal(float normal)
        {
            setter(startValue + difference * normal);
        }
    }
}
