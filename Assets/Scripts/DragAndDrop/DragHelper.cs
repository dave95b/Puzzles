using UnityEngine;
using System.Collections.Generic;

public static class DragHelper
{
    public static Slot GetClosestSlot(Puzzle puzzle, SlotList overlappedSlots)
    {
        Vector3 puzzlePosition = puzzle.transform.position;
        Slot closestSlot = overlappedSlots[0];
        float shortestDistance = (puzzlePosition - closestSlot.transform.position).sqrMagnitude;

        for (int i = 1; i < overlappedSlots.Count; i++)
        {
            Slot slot = overlappedSlots[i];
            float distance = (puzzlePosition - slot.transform.position).sqrMagnitude;

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestSlot = slot;
            }
        }

        return closestSlot;
    }
}
