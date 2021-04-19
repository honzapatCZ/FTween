// Copyright (C) 2021 Nejcraft Do Not Redistribute

using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public class FCallback : FTweener
    {
        public FCallback(Action onComplete) : base(0)
        {
            this.onComplete += onComplete;
        }

        public override FTweener Reverse()
        {
            Debug.LogWarning("You cant reverse a Callback");
            return this;
        }

        internal override void SetupSpeedBased()
        {
            Debug.LogWarning("You cant speedbase a Callback");
        }

        internal override void update(float delta)
        {
            if (!isComplete)
            {
                onComplete?.Invoke();
                _isComplete = true;
                if (parentSeq == null)
                    Kill();
            }
        }
    }
}
