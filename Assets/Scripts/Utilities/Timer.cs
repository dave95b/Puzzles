using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private NativeEvent onGameOver;

    private IEnumerator coroutine;
    private int elapsedSeconds;
    public event Action<int> OnTimeChanged;


    private void Start()
    {
        onGameOver.AddListener(StopTimer);
        coroutine = MeasureTime();
        StartCoroutine(coroutine);
    }

    private IEnumerator MeasureTime()
    {
        var delay = Yielder.WaitForSeconds(1f);
        while (true)
        {
            yield return delay;
            elapsedSeconds++;
            OnTimeChanged?.Invoke(elapsedSeconds);
        }
    }

    private void StopTimer()
    {
        StopCoroutine(coroutine);
    }

    private void OnDisable()
    {
        StopTimer();
        onGameOver.RemoveListener(StopTimer);
        OnTimeChanged = null;
    }
}
