using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour, IMatchSuccessListener, IMatchFailureListener
{
    [SerializeField]
    private float snapToGridDuration = 0.25f, returnDuration = 0.5f;

    [SerializeField]
    private PuzzlePositionRandomizer randomizer;

    public void OnSuccess(Puzzle puzzle, Slot slot)
    {
        puzzle.Animator.MoveTo(slot.transform.position, snapToGridDuration);
        puzzle.enabled = false;
        puzzle.Collider.enabled = false;
    }

    public void OnFailure(Puzzle puzzle, Slot slot)
    {
        Vector3 position = randomizer.GetPosition();
        puzzle.Animator.MoveTo(position, returnDuration, makeInteractable: true);
    }
}
