using UnityEngine;
using System.Collections;
using System;

public class ClosestSlotHighlighter : MonoBehaviour, IDragListener, IDropListener
{
    [SerializeField]
    private SlotList overlappedSlots;

    [SerializeField]
    private Interpolator interpolator;

    [SerializeField]
    private float alpha = 0.25f, animDuration = 0.15f;

    [SerializeField]
    private AnimationCurve curve;


    private SpriteRenderer sprite;
    private Slot lastSlot;
    private Action<Vector3> move;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        move = Move;
    }


    public void OnDrag(Puzzle puzzle)
    {
        if (overlappedSlots.Count == 0)
        {
            if (lastSlot != null)
            {
                SetAlpha(0f);
                lastSlot = null;
            }
            return;
        }

        var slot = DragHelper.GetClosestSlot(puzzle, overlappedSlots);
        MoveHighlightTo(slot);

        lastSlot = slot;
    }

    public void OnDrop(Puzzle puzzle)
    {
        SetAlpha(0f);
        lastSlot = null;
    }


    private void MoveHighlightTo(Slot slot)
    {
        Vector3 slotPosition = slot.transform.position;
        if (lastSlot is null)
            ShowAndMove(slotPosition);
        else if (lastSlot != slot)
            SmoothMoveTo(slotPosition);
    }

    private void SetAlpha(float alpha)
    {
        float startAlpha = sprite.color.a;
        if (startAlpha != alpha)
            AnimationHelper.SpriteFade(interpolator, sprite, startAlpha, alpha, animDuration, curve);
    }

    private void ShowAndMove(Vector3 destination)
    {
        SetAlpha(alpha);
        transform.position = destination;
    }

    private void SmoothMoveTo(Vector3 destination)
    {
        var data = new InterpolationData<Vector3>(move, transform.position, destination, animDuration, curve);
        interpolator.Interpolate(data);
    }

    private void Move(Vector3 position)
    {
        transform.position = position;
    }
}
