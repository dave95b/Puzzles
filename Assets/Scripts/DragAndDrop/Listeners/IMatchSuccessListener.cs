using UnityEngine;
using System.Collections.Generic;

public interface IMatchSuccessListener
{
    void OnSuccess(Puzzle puzzle, Slot slot);
}
