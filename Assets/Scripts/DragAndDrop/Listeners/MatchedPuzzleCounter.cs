using UnityEngine;
using System.Collections;

public class MatchedPuzzleCounter : MonoBehaviour, IMatchSuccessListener
{
    [SerializeField]
    private NativeEvent OnGameOver;

    [SerializeField]
    private Transform puzzleParent;

    [SerializeField]
    private IntValue remainingPuzzles;

    private int puzzleCount;


    private void Awake()
    {
        remainingPuzzles.Value = puzzleCount = puzzleParent.childCount;
    }


    public void OnSuccess(Puzzle puzzle, Slot slot)
    {
        remainingPuzzles--;
        if (remainingPuzzles == 0)
            OnGameOver.Invoke();
    }
}
