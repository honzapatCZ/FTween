using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static class Extensions
    {
        public static FloatFTweener FTLocalMoveY(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(()=>actor.LocalPosition.Y, (y)=> actor.LocalPosition += Vector3.Up * (y - actor.LocalPosition.Y), endPos, time);
        }
        
        public static Vector3FTweener FTLocalRotate(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, endPos, time);
        }
        public static Vector3FTweener FTLocalRotateBy(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles += y - actor.LocalEulerAngles, endPos + actor.LocalEulerAngles, time);
        }

        public static FloatFTweener FTFade(this AudioSource actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Volume, (y) => actor.Volume = y, endPos, time);
        }
    }
}
