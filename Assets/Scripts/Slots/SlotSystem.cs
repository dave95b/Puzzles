using UnityEngine;
using System.Collections;

public class SlotSystem : MonoBehaviour
{
    [SerializeField]
    private Slot[] slots;

    [SerializeField]
    private SlotList overlappedSlots;


    private void Awake()
    {
        InitializeSlots();
    }


    public void OnSlotOverlapEnter(Slot slot)
    {
        overlappedSlots.Add(slot);
    }

    public void OnSlotOverlapExit(Slot slot)
    {
        overlappedSlots.Remove(slot);
    }


    private void InitializeSlots()
    {
        slots = GetComponentsInChildren<Slot>();
        for (int i = 0; i < slots.Length; i++)
        {
            var slot = slots[i];
            slot.Index = i;
            slot.SlotSystem = this;
        }
    }

    private void OnDestroy()
    {
        overlappedSlots.Clear();
    }
}
