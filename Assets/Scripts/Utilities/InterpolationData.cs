using UnityEngine;
using System;

public struct InterpolationData<T> : IEquatable<InterpolationData<T>>
{
    public readonly Action<T> Action;
    public readonly T Start, End;
    public readonly float Duration;
    public readonly AnimationCurve Curve;
    public Action OnEnded;
    public float ElapsedTime;

    public InterpolationData(Action<T> action, T start, T end, float duration, AnimationCurve curve, Action onEnded = null)
    {
        Action = action;
        Start = start;
        End = end;
        Duration = duration;
        Curve = curve;
        OnEnded = onEnded;
        ElapsedTime = 0f;
    }


    public override bool Equals(object obj)
    {
        if (obj is InterpolationData<T> data)
            return Equals(data);

        return false;
    }

    public bool Equals(InterpolationData<T> other)
    {
        return Action == other.Action;
    }

    public override int GetHashCode()
    {
        return Action.GetHashCode();
    }
}
