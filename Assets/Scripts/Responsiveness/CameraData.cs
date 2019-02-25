using UnityEngine;
using System.Collections.Generic;

public readonly struct CameraData
{
    public readonly float AspectRatio;
    public readonly float Width, Height;

    public CameraData(float aspectRatio, float width, float height)
    {
        AspectRatio = aspectRatio;
        Width = width;
        Height = height;
    }
}
