using UnityEngine;
using System.Collections;

public interface IMatchFailureListener
{
    void OnFailure(Puzzle puzzle, Slot slot);
}
