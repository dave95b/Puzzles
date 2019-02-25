using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ScaleData", menuName = "Game data/Scale Data")]
public class ScaleData : ScriptableObject
{
    [SerializeField]
    private float minAspect, maxAspect, minScale, maxScale;

    public float MinAspect => minAspect;
    public float MaxAspect => maxAspect;
    public float MinScale => minScale;
    public float MaxScale => maxScale;
}
