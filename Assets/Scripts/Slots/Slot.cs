using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int Index;

    [HideInInspector]
    public SlotSystem SlotSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SlotSystem.OnSlotOverlapEnter(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SlotSystem.OnSlotOverlapExit(this);
    }
}
