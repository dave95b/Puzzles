using UnityEngine;
using System.Collections;
using NaughtyAttributes;

public class RefreshRateConfigurator : MonoBehaviour
{
    [SerializeField, Slider(30, 72)]
    private int refreshRate = 60;

    private void Awake()
    {
        Application.targetFrameRate = refreshRate;
    }
}
