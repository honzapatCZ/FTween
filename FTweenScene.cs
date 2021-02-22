using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public class FTweenScene : Script
    {
        public List<FTweener> tweens = new List<FTweener>();
        public List<FTweener> toRemoveTweens = new List<FTweener>();

        public override void OnUpdate()
        {
            foreach(FTweener tween in tweens)
            {
                if (!tween.setup)
                    tween.Setup();

                tween.update(Time.DeltaTime);
            }
            foreach(FTweener tween in toRemoveTweens)
            {
                tweens.Remove(tween);
            }
        }
        public static FTweenScene _instance;

        public static FTweenScene Instance {
            get
            {
                if(_instance == null)
                {
                    Actor act = new EmptyActor();
                    Level.SpawnActor(act);
                    _instance = act.AddScript(typeof(FTweenScene)) as FTweenScene;
                }
                return _instance;
            }
            set
            {
                if(_instance != null)
                {
                    Debug.LogWarning("Tried to assign new FTweenScene when the current is not null");
                    return;
                }
                _instance = value;
            }
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            if(_instance == this)
            {
                _instance = null;
            }
        }

        public void AddT(FTweener tween)
        {
            if (tweens.Contains(tween))
            {
                Debug.LogWarning("Tried to add duplicate tween to manager");
            }
            tweens.Add(tween);
        }
        public void RemoveT(FTweener tween)
        {
            if (!tweens.Contains(tween))
            {
                Debug.LogWarning("Tried to remove non exstant tween from manager");
            }
            toRemoveTweens.Add(tween);
        }

        public static void AddTween(FTweener tween)
        {
            Instance.AddT(tween);
        }
        public static void RemoveTween(FTweener tween)
        {
            Instance.RemoveT(tween);
        }
    }
}
