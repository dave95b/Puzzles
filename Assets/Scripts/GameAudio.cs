using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip matchSuccess, gameOver;

    private AudioSource audio;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    

    public void PlayMatchSuccess()
    {
        PlayClip(matchSuccess);
    }

    public void PlayGameOver()
    {
        PlayClip(gameOver);
    }


    private void PlayClip(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
