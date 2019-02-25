using UnityEngine;
using System.Collections;

public class PuzzleAnimator : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve moveCurve, rotateCurve;

    [SerializeField]
    private float rotateDuration = 0.25f, shadowFadeDuration = 0.15f;

    [HideInInspector]
    public Interpolator Interpolator;

    [HideInInspector]
    public PuzzleOrderController OrderController;

    private Puzzle puzzle;


    private void Awake()
    {
        puzzle = GetComponent<Puzzle>();
    }


    public void Rotate()
    {
        SetInteractable(false);
        puzzle.Rotation = (++puzzle.Rotation) % 4;

        Vector3 currentRotation = puzzle.transform.rotation.eulerAngles;
        Vector3 targetRotation = currentRotation - new Vector3(0f, 0f, 90f);

        var data = new InterpolationData<Vector3>(ChangeRotation, currentRotation, targetRotation, rotateDuration, AnimationHelper.LinearCurve, MakeInteractable);
        Interpolator.Interpolate(data);

        OrderController.MoveToTop(puzzle);
    }

    public void ShowShadow()
    {
        SetShadowAlpha(0f, 1f);
    }
    
    public void HideShadow()
    {
        SetShadowAlpha(1f, 0f);
    }

    private void SetShadowAlpha(float startAlpha, float endAlpha)
    {
        AnimationHelper.SpriteFade(Interpolator, puzzle.Shadow, startAlpha, endAlpha, shadowFadeDuration, AnimationHelper.LinearCurve);
    }

    public void MoveTo(Vector3 destination, float duration, float initialDelay = 0.15f, bool makeInteractable = false)
    {
        SetInteractable(false);
        StartCoroutine(AnimateMove(destination, duration, initialDelay, makeInteractable));
    }

    private IEnumerator AnimateMove(Vector3 destination, float duration, float initialDelay, bool enableCollider)
    {
        Vector3 origin = transform.position;
        yield return Yielder.WaitForSeconds(initialDelay);

        InterpolationData<Vector3> interpolationData = new InterpolationData<Vector3>(ChangePosition, origin, destination, duration, moveCurve);
        if (enableCollider)
            interpolationData.OnEnded = MakeInteractable;

        Interpolator.Interpolate(interpolationData);
    }

    private void ChangePosition(Vector3 newPosition)
    {
        puzzle.Rigidbody2D.MovePosition(newPosition);
    }

    private void ChangeRotation(Vector3 rotation)
    {
        puzzle.transform.rotation = Quaternion.Euler(rotation);
    }


    private void SetInteractable(bool status)
    {
        puzzle.Collider.enabled = status;
    }

    private void MakeInteractable()
    {
        SetInteractable(true);
    }
}
