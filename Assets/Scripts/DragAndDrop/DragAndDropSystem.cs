using UnityEngine;
using System.Collections;

public class DragAndDropSystem : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private SlotList overlappedSlots;

    private IBeginDragListener[] beginDragListeners;
    private IDragListener[] dragListeners;
    private IDropListener[] dropListeners;

    private IMatchSuccessListener[] successListeners;
    private IMatchFailureListener[] failureListeners;

    private Vector2 dragDelta;


    private void Awake()
    {
        beginDragListeners = GetComponentsInChildren<IBeginDragListener>();
        dragListeners = GetComponentsInChildren<IDragListener>();
        dropListeners = GetComponentsInChildren<IDropListener>();
        successListeners = GetComponentsInChildren<IMatchSuccessListener>();
        failureListeners = GetComponentsInChildren<IMatchFailureListener>();
    }


    public void OnBeginDrag(Puzzle puzzle, Vector2 dragPosition)
    {
        Vector2 screenPosition = camera.ScreenToWorldPoint(dragPosition);
        dragDelta = puzzle.Rigidbody2D.position - screenPosition;

        foreach (var listener in beginDragListeners)
            listener.OnBeginDrag(puzzle);
    }

    public void OnDrag(Puzzle puzzle, Vector2 dragPosition)
    {
        Vector2 screenPosition = camera.ScreenToWorldPoint(dragPosition);
        puzzle.Rigidbody2D.MovePosition(screenPosition + dragDelta);

        foreach (var listener in dragListeners)
            listener.OnDrag(puzzle);
    }

    public void OnDrop(Puzzle puzzle, Vector2 dragPosition)
    {
        foreach (var listener in dropListeners)
            listener.OnDrop(puzzle);

        if (overlappedSlots.Count == 0)
            return;

        Slot slot = DragHelper.GetClosestSlot(puzzle, overlappedSlots);

        if (Match(puzzle, slot))
            Success(puzzle, slot);
        else
            Failure(puzzle, slot);
    }

    private bool Match(Puzzle puzzle, Slot slot)
    {
        return puzzle.Rotation == 0 && puzzle.Index == slot.Index;
    }


    private void Success(Puzzle puzzle, Slot slot)
    {
        foreach (var listener in successListeners)
            listener.OnSuccess(puzzle, slot);
    }

    private void Failure(Puzzle puzzle, Slot slot)
    {
        foreach (var listener in failureListeners)
            listener.OnFailure(puzzle, slot);
    }
}
