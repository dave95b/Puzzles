using UnityEngine;
using System.Collections;

public class GalleryItemView : MonoBehaviour
{
    public Sprite Image
    {
        set => renderer.sprite = value;
    }

    private SpriteRenderer renderer;
    public SpriteRenderer Renderer => renderer;

    [HideInInspector]
    public Interpolator Interpolator;

    [SerializeField]
    private SpriteRenderer shadowRenderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    public void FadeIn(float duration, AnimationCurve curve)
    {
        AnimationHelper.SpriteFade(Interpolator, renderer, 0f, 1f, duration, curve);
        AnimationHelper.SpriteFade(Interpolator, shadowRenderer, 0f, 1f, duration, curve);
    }

    public void FadeOut(float duration, AnimationCurve curve)
    {
        AnimationHelper.SpriteFade(Interpolator, renderer, 1f, 0f, duration, curve);
        AnimationHelper.SpriteFade(Interpolator, shadowRenderer, 1f, 0f, duration, curve);
    }

    public void Show()
    {
        SetImagesAlpha(1f);
    }

    public void Hide()
    {
        SetImagesAlpha(0f);
    }

    private void SetImagesAlpha(float alpha)
    {
        var color = renderer.color;
        var shadowColor = shadowRenderer.color;
        color.a = alpha;
        shadowColor.a = alpha;
        renderer.color = color;
        shadowRenderer.color = shadowColor;
    }
}
