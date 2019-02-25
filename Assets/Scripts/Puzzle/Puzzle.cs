using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class Puzzle : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Sprite Sprite
    {
        get => spriteRenderer.sprite;
        set => spriteRenderer.sprite = value;
    }

    public int Index;

    public int SortingOrder
    {
        set
        {
            spriteRenderer.sortingOrder = value;
            Shadow.sortingOrder = value - 1;
        }
    }

    public int Rotation;

    public SpriteRenderer Shadow;


    [SerializeField, GetComponent, HideInInspector]
    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public PuzzleAnimator Animator;
    [HideInInspector]
    public Rigidbody2D Rigidbody2D;
    [HideInInspector]
    public Collider2D Collider;

    private DragAndDropSystem system;


    private void Awake()
    {
        Animator = GetComponent<PuzzleAnimator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        system = GetComponentInParent<DragAndDropSystem>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        system.OnBeginDrag(this, eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        system.OnDrag(this, eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        system.OnDrop(this, eventData.position);
    }
}
