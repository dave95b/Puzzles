using UnityEngine;
using System.Collections;

public class PuzzlePositionRandomizer : MonoBehaviour
{
    [SerializeField]
    private Transform topLeftBound, bottomRightBound;
    private Vector3 topLeftPosition, bottomRightPosition;


    //private void Awake()
    private void Start()
    {
        topLeftPosition = topLeftBound.transform.position;
        bottomRightPosition = bottomRightBound.transform.position;
    }

    public Vector3 GetPosition()
    {
        float x = Random.Range(topLeftPosition.x, bottomRightPosition.x);
        float y = Random.Range(topLeftPosition.y, bottomRightPosition.y);

        return new Vector3(x, y, 0f);
    }
}
