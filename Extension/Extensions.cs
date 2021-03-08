using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static class Extensions
    {
        public static Vector2FTweener FTLocation(this FlaxEngine.GUI.Control actor, Vector2 endPos, float time)
        {
            return new Vector2FTweener(() => actor.Location, (y) => actor.Location = y, endPos, time);
        }
        public static FloatFTweener FTLocationX(this FlaxEngine.GUI.Control actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Location.X, (y) => actor.Location += new Vector2(1, 0) * (y - actor.Location.X), endPos, time);
        }
        public static FloatFTweener FTLocationY(this FlaxEngine.GUI.Control actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Location.Y, (y) => actor.Location += new Vector2(0, 1) * (y - actor.Location.Y), endPos, time);
        }
        public static Sequence FTShakeRotation(this FlaxEngine.GUI.Control actor, float time, float strength = 90, int vibrato = 10, float randomness = 90, bool fade = true)
        {
            return FloatFTweener.Shake(() => actor.Rotation, (y) =>actor.Rotation += y - actor.Rotation, actor.Rotation, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakeScale(this FlaxEngine.GUI.Control actor, float time, float strength = 90, int vibrato = 10, float randomness = 90, bool fade = true)
        {
            return Vector2FTweener.Shake(() => actor.Scale, (y) => actor.Scale += y - actor.Scale, actor.Scale, time, strength, vibrato, randomness, fade);
        }

        public static Vector3FTweener FTMove(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.Position, (y) => actor.Position = y, endPos, time);
        }
        public static FloatFTweener FTMoveX(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Position.X, (y) => actor.Position += Vector3.Right * (y - actor.Position.X), endPos, time);
        }
        public static FloatFTweener FTMoveY(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Position.Y, (y) => actor.Position += Vector3.Up * (y - actor.Position.Y), endPos, time);
        }
        public static FloatFTweener FTMoveZ(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Position.Z, (y) => actor.Position += Vector3.Forward * (y - actor.Position.Z), endPos, time);
        }

        public static Vector3FTweener FTLocalMove(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalPosition, (y) => actor.LocalPosition = y, endPos, time);
        }
        public static FloatFTweener FTLocalMoveX(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalPosition.X, (y) => actor.LocalPosition += Vector3.Right * (y - actor.LocalPosition.X), endPos, time);
        }
        public static FloatFTweener FTLocalMoveY(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(()=>actor.LocalPosition.Y, (y)=> actor.LocalPosition += Vector3.Up * (y - actor.LocalPosition.Y), endPos, time);
        }
        public static FloatFTweener FTLocalMoveZ(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalPosition.Z, (y) => actor.LocalPosition += Vector3.Forward * (y - actor.LocalPosition.Z), endPos, time);
        }

        public static Vector3FTweener FTScale(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalScale, (y) => actor.LocalScale = y, endPos, time);
        }
        public static FloatFTweener FTScaleX(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalScale.X, (y) => actor.LocalScale += Vector3.Right * (y - actor.LocalScale.X), endPos, time);
        }
        public static FloatFTweener FTScaleY(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalScale.Y, (y) => actor.LocalScale += Vector3.Up * (y - actor.LocalScale.Y), endPos, time);
        }
        public static FloatFTweener FTScaleZ(this Actor actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalScale.Z, (y) => actor.LocalScale += Vector3.Forward * (y - actor.LocalScale.Z), endPos, time);
        }

        public static Vector3FTweener FTLocalRotate(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, endPos, time);
        }
        public static Vector3FTweener FTLocalRotateBy(this Actor actor, Vector3 endPos, float time)
        {
            return new Vector3FTweener(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles += y - actor.LocalEulerAngles, endPos + actor.LocalEulerAngles, time);
        }
        public static QuaternionFTweener FTRotateQuaternion(this Actor actor, Quaternion endPos, float time)
        {
            return new QuaternionFTweener(() => actor.Orientation, (y) => actor.Orientation = y, endPos, time);
        }
        public static QuaternionFTweener FTLocalRotateQuaternion(this Actor actor, Quaternion endPos, float time)
        {
            return new QuaternionFTweener(() => actor.LocalOrientation, (y) => actor.LocalOrientation = y, endPos, time);
        }

        public static FloatFTweener FTFade(this AudioSource actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.Volume, (y) => actor.Volume = y, endPos, time);
        }
    }
}
