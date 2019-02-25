using UnityEngine;
using System.Collections.Generic;

public abstract class InterpolationHandler<T>
{
    private List<InterpolationData<T>> interpolations = new List<InterpolationData<T>>(4);


    public void AddOrRefresh(in InterpolationData<T> data)
    {
        int index = interpolations.IndexOf(data);
        if (index == -1)
            interpolations.Add(data);
        else
            interpolations[index] = data;
    }

    public void Interpolate(float deltaTime)
    {
        for (int i = interpolations.Count - 1; i >= 0; i--)
        {
            var data = interpolations[i];
            data.ElapsedTime += deltaTime;

            EvaluateInterpolation(data);
            FinishOrContinue(data, i);
        }
    }


    private void EvaluateInterpolation(in InterpolationData<T> data)
    {
        float percent = data.ElapsedTime / data.Duration;
        float curvePercent = data.Curve.Evaluate(percent);

        T newValue = CalculateInterpolatedValue(data, curvePercent);
        data.Action.Invoke(newValue);
    }

    protected abstract T CalculateInterpolatedValue(in InterpolationData<T> data, float curvePercent);

    private void FinishOrContinue(in InterpolationData<T> data, int index)
    {
        if (data.ElapsedTime > data.Duration)
        {
            data.Action.Invoke(data.End);
            data.OnEnded?.Invoke();
            interpolations.RemoveAt(index);
        }
        else
            interpolations[index] = data;
    }
}
