using UnityEngine;
using System.Collections;

public class PuzzleBoundsPositionHandler : CameraDataHandler
{
    [SerializeField]
    private Transform topLeftBound, bottomRightBound, bottomSlot;
    
    [SerializeField]
    private float margin;


    public override void HandleCameraData(in CameraData data)
    {
        float slotSize = bottomSlot.transform.localScale.x;
        float offset = data.Width / 2f - margin - (slotSize / 2f);

        SetTopLeftPosition(-offset, slotSize);
        SetBottomRightPosition(offset, data.Height, slotSize);
    }

    private void SetTopLeftPosition(float offset, float slotSize)
    {
        Vector3 position = topLeftBound.position;
        position.x = offset;
        position.y = bottomSlot.position.y - slotSize - margin;
        topLeftBound.position = position;
    }

    private void SetBottomRightPosition(float offset, float cameraHeight, float slotSize)
    {
        Vector3 position = bottomRightBound.position;
        position.x = offset;
        position.y = (-cameraHeight / 2f) + (slotSize / 2f) + margin;
        bottomRightBound.position = position;
    }
}
