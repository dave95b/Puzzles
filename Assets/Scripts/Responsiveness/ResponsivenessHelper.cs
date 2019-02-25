using UnityEngine;
using System.Collections.Generic;

public static class ResponsivenessHelper
{
    public static float GetScale(ScaleData scaleData, float aspectRatio)
    {
        float aspectProportion = Mathf.InverseLerp(scaleData.MinAspect, scaleData.MaxAspect, aspectRatio);
        return Mathf.Lerp(scaleData.MinScale, scaleData.MaxScale, aspectProportion);
    }

    public static void ScaleAndTranslate(PositionCorrector[] correctors, float scale)
    {
        foreach (var corrector in correctors)
        {
            var transform = corrector.transform;
            transform.localScale *= scale;
            corrector.CorrectPosition(scale);
        }
    }
}
