using UnityEngine;
using System.Collections.Generic;
using System;

public static class AnimationHelper
{
    public static AnimationCurve LinearCurve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));


    public static void SpriteFade(Interpolator interpolator, SpriteRenderer sprite, float startAplha, float endAlpha, float duration, AnimationCurve curve, Action onEnded = null)
    {
        void fade(float alpha)
        {
            var color = sprite.color;
            color.a = alpha;
            sprite.color = color;
        }

        var interpolationData = new InterpolationData<float>(fade, startAplha, endAlpha, duration, curve, onEnded);
        interpolator.Interpolate(interpolationData);
    }
}
