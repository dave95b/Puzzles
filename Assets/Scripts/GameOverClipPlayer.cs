using UnityEngine;
using System.Collections;

public class GameOverClipPlayer : MonoBehaviour
{
    [SerializeField]
    private NativeEvent onGameOver;

    private GameAudio audio;


    private void Awake()
    {
        audio = GetComponent<GameAudio>();
        onGameOver.AddListener(PlayGameOverClip);
    }

    private void PlayGameOverClip()
    {
        audio.PlayGameOver();
    }

    private void OnDestroy()
    {
        onGameOver.RemoveListener(PlayGameOverClip);
    }
}