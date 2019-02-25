using UnityEngine;
using System.Collections;
using NaughtyAttributes;

public class PuzzleInitializer : MonoBehaviour
{
    [SerializeField]
    private SpriteList sprites;

    [SerializeField, GetComponent(GetComponentScope.Children)]
    private Puzzle[] puzzles;

    [SerializeField]
    private PuzzlePositionRandomizer randomizer;

    [SerializeField]
    private Interpolator interpolator;

    [SerializeField]
    private PuzzleOrderController orderController;


    //private void Awake()
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            var puzzle = puzzles[i];
            puzzle.Index = i;
            puzzle.SortingOrder = i;
            puzzle.Sprite = sprites[i];
            puzzle.Animator.Interpolator = interpolator;
            puzzle.Animator.OrderController = orderController;
            Rotate(puzzle);
            Translate(puzzle);
        }
        orderController.TopOrder = puzzles.Length;
    }


    private void Rotate(Puzzle puzzle)
    {
        float baseRotation = -90f;
        int rotation = Random.Range(0, 3);

        puzzle.Rotation = rotation;
        puzzle.transform.eulerAngles = new Vector3(0f, 0f, rotation * baseRotation);
    }

    private void Translate(Puzzle puzzle)
    {
        Vector3 position = randomizer.GetPosition();
        puzzle.Animator.MoveTo(position, 0.5f, initialDelay:0f, makeInteractable: true);
    }
}
