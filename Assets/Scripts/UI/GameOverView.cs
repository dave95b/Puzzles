using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    [SerializeField]
    private Interpolator interpolator;

    [SerializeField]
    private NativeEvent onGameOver;


    [Header("Background Animation"), SerializeField]
    private AnimationCurve backgroundFadeCurve;

    [SerializeField]
    private float backgroundFadeDuration = 0.5f;


    [Header("Panel Animation"), SerializeField]
    private RectTransform panel;

    [SerializeField]
    private AnimationCurve panelCurve;

    [SerializeField]
    private float panelSlideDuration = 0.5f, panelStartPosition = 800f;

    private Rect panelRect;


    private Canvas canvas;
    private Image background;

    private float backgroundAlpha;


    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        background = GetComponent<Image>();
        backgroundAlpha = background.color.a;
        panelRect = panel.rect;

        onGameOver.AddListener(ShowView);
    }

    private void ShowView()
    {
        canvas.enabled = true;
        AnimateBackground();
        AnimatePanel();
    }

    private void AnimateBackground()
    {
        var data = new InterpolationData<float>(SetBackgroundAlpha, 0f, backgroundAlpha, backgroundFadeDuration, backgroundFadeCurve);
        interpolator.Interpolate(data);
    }

    private void SetBackgroundAlpha(float alpha)
    {
        var color = background.color;
        color.a = alpha;
        background.color = color;
    }


    private void AnimatePanel()
    {
        var data = new InterpolationData<float>(SetPanelPosition, panelStartPosition, 0f, panelSlideDuration, panelCurve);
        interpolator.Interpolate(data);
    }

    private void SetPanelPosition(float position)
    {
        panel.anchoredPosition = new Vector2(position, 0f);
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }


    private void OnDestroy()
    {
        onGameOver.RemoveListener(ShowView);
    }
}
