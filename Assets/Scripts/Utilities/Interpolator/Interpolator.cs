using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Interpolator : MonoBehaviour
{
    private InterpolationHandler<float> floatHandler = new FloatInterpolationHandler();
    private InterpolationHandler<Vector3> vectorHandler = new Vector3InterpolationHandler();


    private void Update()
    {
        float deltaTime = Time.deltaTime;
        floatHandler.Interpolate(deltaTime);
        vectorHandler.Interpolate(deltaTime);
    }


    public void Interpolate(in InterpolationData<float> data)
    {
        floatHandler.AddOrRefresh(data);
    }

    public void Interpolate(in InterpolationData<Vector3> data)
    {
        vectorHandler.AddOrRefresh(data);
    }
}
