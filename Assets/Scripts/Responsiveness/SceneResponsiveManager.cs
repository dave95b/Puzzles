using UnityEngine;
using System.Collections;

public class SceneResponsiveManager : CameraDataHandler
{
    [SerializeField]
    private ScaleData scaleData;

    [SerializeField]
    private Transform[] toScale;

    [SerializeField]
    private PositionCorrector[] positionCorrectors;


    public override void HandleCameraData(in CameraData data)
    {
        float scale = ResponsivenessHelper.GetScale(scaleData, data.AspectRatio);

        foreach (var transform in toScale)
            transform.localScale *= scale;

        ResponsivenessHelper.ScaleAndTranslate(positionCorrectors, scale);
    }
}
