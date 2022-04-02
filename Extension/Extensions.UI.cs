using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FTween
{
    public static partial class Extensions
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
        public static Sequence FTShakeLocation(this FlaxEngine.GUI.Control actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return Vector2FTweener.Shake(() => actor.Location, (y) => actor.Location = y, actor.Location, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakeRotation(this FlaxEngine.GUI.Control actor, float time, float strength = 90, int vibrato = 10, float randomness = 90, bool fade = true)
        {
            return FloatFTweener.Shake(() => actor.Rotation, (y) =>actor.Rotation = y, actor.Rotation, time, strength, vibrato, randomness, fade);
        }
        public static Sequence FTShakeScale(this FlaxEngine.GUI.Control actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return Vector2FTweener.Shake(() => actor.Scale, (y) => actor.Scale = y, actor.Scale, time, strength, vibrato, randomness, fade);
        }

        public static Vector2FTweener FTLocalLocation(this FlaxEngine.GUI.Control actor, Vector2 endPos, float time)
        {
            return new Vector2FTweener(() => actor.LocalLocation, (y) => actor.LocalLocation = y, endPos, time);
        }
        public static FloatFTweener FTLocalLocationX(this FlaxEngine.GUI.Control actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalLocation.X, (y) => actor.LocalLocation += new Vector2(1, 0) * (y - actor.LocalLocation.X), endPos, time);
        }
        public static FloatFTweener FTLocalLocationY(this FlaxEngine.GUI.Control actor, float endPos, float time)
        {
            return new FloatFTweener(() => actor.LocalLocation.Y, (y) => actor.LocalLocation += new Vector2(0, 1) * (y - actor.LocalLocation.Y), endPos, time);
        }
        public static Sequence FTShakeLocalLocation(this FlaxEngine.GUI.Control actor, float time, float strength = 2, int vibrato = 2, float randomness = 2, bool fade = true)
        {
            return Vector2FTweener.Shake(() => actor.LocalLocation, (y) => actor.LocalLocation = y, actor.LocalLocation, time, strength, vibrato, randomness, fade);
        }
    }
}
