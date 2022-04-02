using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static partial class Extensions
    {
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
            return new Vector3FTweener(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, endPos + actor.LocalEulerAngles, time);
        }
        public static QuaternionFTweener FTRotateQuaternion(this Actor actor, Quaternion endPos, float time)
        {
            return new QuaternionFTweener(() => actor.Orientation, (y) => actor.Orientation = y, endPos, time);
        }
        public static QuaternionFTweener FTLocalRotateQuaternion(this Actor actor, Quaternion endPos, float time)
        {
            return new QuaternionFTweener(() => actor.LocalOrientation, (y) => actor.LocalOrientation = y, endPos, time);
        }



        public static Sequence FTShakePosition(this Actor actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return Vector3FTweener.Shake(() => actor.LocalPosition, (y) => actor.LocalPosition = y, actor.LocalPosition, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakePositionX(this Actor actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return FloatFTweener.Shake(() => actor.LocalPosition.X, (y) => actor.LocalPosition += Vector3.Right * (y - actor.LocalPosition.X), actor.LocalPosition.X, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakePositionY(this Actor actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return FloatFTweener.Shake(() => actor.LocalPosition.Y, (y) => actor.LocalPosition += Vector3.Up * (y - actor.LocalPosition.Y), actor.LocalPosition.Y, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakePositionZ(this Actor actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return FloatFTweener.Shake(() => actor.LocalPosition.Z, (y) => actor.LocalPosition += Vector3.Forward * (y - actor.LocalPosition.Z), actor.LocalPosition.Z, time, strength, vibrato, randomness, fade);
        }

        public static Sequence FTShakeRotation(this Actor actor, float time, float strength = 90, int vibrato = 10, float randomness = 90, bool fade = true)
        {
            return Vector3FTweener.Shake(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, actor.LocalEulerAngles, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakeScale(this Actor actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return Vector3FTweener.Shake(() => actor.LocalScale, (y) => actor.LocalScale = y, actor.LocalScale, time, strength, vibrato, randomness, fade);
        }



        public static Sequence FTJumpPosition(this Actor actor, float time, float strength = 2, int jumps = 2, float randomness = 2)
        {
            return Vector3FTweener.Jump(() => actor.LocalPosition, (y) => actor.LocalPosition = y, actor.LocalPosition, time, strength, jumps, randomness);
        }
        public static Sequence FTJumpPositionX(this Actor actor, float time, float strength = 2, int jumps = 2, float randomness = 2)
        {
            return FloatFTweener.Jump(() => actor.LocalPosition.X, (y) => actor.LocalPosition += Vector3.Right * (y - actor.LocalPosition.X), actor.LocalPosition.X, time, strength, jumps, randomness);
        }
        public static Sequence FTJumpPositionY(this Actor actor, float time, float strength = 2, int jumps = 2, float randomness = 2)
        {
            return FloatFTweener.Jump(() => actor.LocalPosition.Y, (y) => actor.LocalPosition += Vector3.Up * (y - actor.LocalPosition.Y), actor.LocalPosition.Y, time, strength, jumps, randomness);
        }
        public static Sequence FTJumpPositionZ(this Actor actor, float time, float strength = 2, int jumps = 2, float randomness = 2)
        {
            return FloatFTweener.Jump(() => actor.LocalPosition.Z, (y) => actor.LocalPosition += Vector3.Forward * (y - actor.LocalPosition.Z), actor.LocalPosition.Z, time, strength, jumps, randomness);
        }

        public static Sequence FTJumpRotation(this Actor actor, float time, float strength = 90, int jumps = 10, float randomness = 90)
        {
            return Vector3FTweener.Jump(() => actor.LocalEulerAngles, (y) => actor.LocalEulerAngles = y, actor.LocalEulerAngles, time, strength, jumps, randomness);
        }
        public static Sequence FTJumpScale(this Actor actor, float time, float strength = 2, int jumps = 2, float randomness = 2)
        {
            return Vector3FTweener.Jump(() => actor.LocalScale, (y) => actor.LocalScale = y, actor.LocalScale, time, strength, jumps, randomness);
        }
    }
}
