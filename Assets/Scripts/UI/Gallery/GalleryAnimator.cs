using UnityEngine;
using System.Collections;
using System;

public class GalleryAnimator : MonoBehaviour
{
    private Gallery gallery;

    [SerializeField]
    private Transform scroll;

    [Header("Slide animation"), SerializeField]
    private Interpolator interpolator;

    [SerializeField]
    private AnimationCurve slideCurve;

    [SerializeField]
    private float slideDuration;

    [Header("Fade animation"), SerializeField]
    private AnimationCurve fadeCurve;

    [SerializeField]
    private float fadeDuration;

    private Collider2D collider;

    private Action<Vector3> slide;
    private Action enableCollider;


    private void Awake()
    {
        gallery = GetComponent<Gallery>();
        collider = GetComponent<Collider2D>();

        slide = Slide;
        enableCollider = EnableCollider;
    }


    public void SlideLeft()
    {
        AnimateSlide();

        var viewHolder = gallery.ViewHolder;
        viewHolder.Left.FadeOut(fadeDuration, fadeCurve);
        viewHolder.Current.FadeIn(fadeDuration, fadeCurve);
    }

    public void SlideRight()
    {
        AnimateSlide();

        var viewHolder = gallery.ViewHolder;
        viewHolder.Right.FadeOut(fadeDuration, fadeCurve);
        viewHolder.Current.FadeIn(fadeDuration, fadeCurve);
    }

    private void AnimateSlide()
    {
        Vector3 destination = gallery.GetSlidePosition();
        collider.enabled = false;
        var data = new InterpolationData<Vector3>(slide, scroll.localPosition, destination, slideDuration, slideCurve, enableCollider);
        interpolator.Interpolate(data);
    }


    private void Slide(Vector3 position)
    {
        scroll.localPosition = position;
    }

    private void EnableCollider()
    {
        collider.enabled = true;
    }
}
