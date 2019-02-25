using UnityEngine;
using System.Collections;

public class AudioClipHandler : MonoBehaviour, IMatchSuccessListener
{
    [SerializeField]
    private GameAudio audio;

    [SerializeField]
    private IntValue remainingPuzzles;

    public void OnSuccess(Puzzle puzzle, Slot slot)
    {
        if (remainingPuzzles > 0)
            audio.PlayMatchSuccess();
        else
            audio.PlayGameOver();
    }
}
