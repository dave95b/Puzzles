using UnityEngine;
using NaughtyAttributes;
using UnityEngine.EventSystems;

public class ClickRotate : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PuzzleAnimator animator;

    private void Awake()
    {
        animator = GetComponent<PuzzleAnimator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.dragging)
            animator.Rotate();
    }
}
