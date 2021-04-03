using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public class FTweenScene : GamePlugin
    {
        public List<FTweener> tweens = new List<FTweener>();
        public List<FTweener> toAddTweens = new List<FTweener>();
        public List<FTweener> toRemoveTweens = new List<FTweener>();

        public override void Initialize()
        {
            base.Initialize();
            Scripting.Update += OnUpdate;
        }
        public override void Deinitialize()
        {
            Scripting.Update -= OnUpdate;
            tweens.Clear();
            toAddTweens.Clear();
            toRemoveTweens.Clear();
            base.Deinitialize();
        }
        public override PluginDescription Description => new PluginDescription {
            Name = "FTween Runtime Game Plugin",
            Version = new Version(0,1),
            Author = "honzapat_CZ",
            AuthorUrl = "https://github.com/honzapatCZ, https://nejcraft.cz",
            HomepageUrl = "https://github.com/honzapatCZ/FTween",
            RepositoryUrl = "https://github.com/honzapatCZ/FTween",
            Description = "This is the runtime plugin of FTween it manages tween updates",
            Category = "Utility, Tweening",
            IsBeta = true,
            IsAlpha = false
        };

        void OnUpdate()
        {
            foreach (FTweener tween in toAddTweens)
            {
                tweens.Add(tween);
                if (!tween.setup)
                    tween.Setup();
            }
            toAddTweens.Clear();

            foreach (FTweener tween in tweens)
            {
                tween.update(Time.DeltaTime);
            }
            foreach (FTweener tween in toRemoveTweens)
            {
                tweens.Remove(tween);
            }
            toRemoveTweens.Clear();
        }

        public static FTweenScene Instance {
            get
            {
                return PluginManager.GetPlugin<FTweenScene>();
            }
        }

        public void AddT(FTweener tween)
        {
            if (tweens.Contains(tween))
            {
                Debug.LogWarning("Tried to add duplicate tween to manager");
                return;
            }
            toAddTweens.Add(tween);
        }
        public void RemoveT(FTweener tween)
        {
            if (!tweens.Contains(tween))
            {
                return;
            }
            toRemoveTweens.Add(tween);
        }

        public static void AddTween(FTweener tween)
        {
            if (!Platform.IsInMainThread)
            {
                Scripting.InvokeOnUpdate(() => {
                    AddTween(tween);
                });
                return;
            }
            Instance.AddT(tween);
        }
        public static void RemoveTween(FTweener tween)
        {
            if (!Platform.IsInMainThread)
            {
                Scripting.InvokeOnUpdate(() => {
                    RemoveTween(tween);
                });
                return;
            }
            Instance.RemoveT(tween);
        }
    }
}
