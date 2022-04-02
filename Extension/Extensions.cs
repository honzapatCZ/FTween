using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static partial class Extensions
    {
        public static FloatFTweener FTFade(this AudioSource actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Volume, (y) => actor.Volume = y, endPos, time);
        }
    }
}
