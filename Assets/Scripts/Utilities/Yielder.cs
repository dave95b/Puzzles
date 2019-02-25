using System;
using System.Collections.Generic;
using UnityEngine;

public static class Yielder {

    private static Dictionary<float, WaitForSeconds> timeIntervals = new Dictionary<float, WaitForSeconds>(50);

    private static WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();
    public static WaitForEndOfFrame EndOfFrame { get { return endOfFrame; } }

    private static WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    public static WaitForFixedUpdate FixedUpdate { get { return fixedUpdate; } }

    public static WaitForSeconds @WaitForSeconds(float seconds) {
        if (!timeIntervals.ContainsKey(seconds))
            timeIntervals.Add(seconds, new WaitForSeconds(seconds));
        return timeIntervals[seconds];
    }
}
