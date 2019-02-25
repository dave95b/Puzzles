using UnityEngine;
using System.Collections;

public class PuzzleOrderController : MonoBehaviour, IBeginDragListener
{
    public int TopOrder;

    public void MoveToTop(Puzzle puzzle)
    {
        TopOrder += 2; //Puzzle sprite and shadow sprite
        puzzle.SortingOrder = TopOrder;
    }

    public void OnBeginDrag(Puzzle puzzle)
    {
        MoveToTop(puzzle);
    }
}
