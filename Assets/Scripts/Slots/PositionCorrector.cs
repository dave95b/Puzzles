using UnityEngine;
using System.Collections.Generic;

public class PositionCorrector : MonoBehaviour
{
    [SerializeField]
    private float baseScale, baseHeight;


    public void CorrectPosition(float scale)
    {
        float scaleModifier = scale / baseScale;
        float height = baseHeight * scaleModifier;
        float moveOffset = (height - baseHeight) / 2f;

        transform.position -= new Vector3(0f, moveOffset, 0f);
    }
}
