using UnityEngine;
using System.Collections;

public class PuzzleShadowController : MonoBehaviour, IBeginDragListener, IDropListener
{
    public void OnBeginDrag(Puzzle puzzle)
    {
        puzzle.Animator.ShowShadow();
    }

    public void OnDrop(Puzzle puzzle)
    {
        puzzle.Animator.HideShadow();
    }
}
