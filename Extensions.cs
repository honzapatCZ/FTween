using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static class Extensions
    {
        public static FloatFTween FTLocalMoveY(this Actor actor, float endPos, float time)
        {
            return new FloatFTween(()=>actor.LocalPosition.Y, (y)=> actor.LocalPosition += Vector3.Up * (y - actor.LocalPosition.Y), endPos, time);
        }
        
        public static Vector3FTween FTLocalRotate(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTween(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, endPos, time);
        }
        public static Vector3FTween FTLocalRotateBy(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTween(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles += y - actor.LocalEulerAngles, endPos + actor.LocalEulerAngles, time);
        }

        public static FloatFTween FTFade(this AudioSource actor, float endPos, float time)
        {
            return new FloatFTween(() => actor.Volume, (y) => actor.Volume = y, endPos, time);
        }
    }
}
