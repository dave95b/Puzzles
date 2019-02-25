using UnityEngine;
using System.Collections.Generic;

public sealed class FloatInterpolationHandler : InterpolationHandler<float>
{
    protected override float CalculateInterpolatedValue(in InterpolationData<float> data, float curvePercent)
    {
        return Mathf.LerpUnclamped(data.Start, data.End, curvePercent);
    }
}

public sealed class Vector3InterpolationHandler : InterpolationHandler<Vector3>
{
    protected override Vector3 CalculateInterpolatedValue(in InterpolationData<Vector3> data, float curvePercent)
    {
        return Vector3.LerpUnclamped(data.Start, data.End, curvePercent);
    }
}
