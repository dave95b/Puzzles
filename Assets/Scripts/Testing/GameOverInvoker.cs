using UnityEngine;
using System.Collections;

public class GameOverInvoker : MonoBehaviour
{
    [SerializeField]
    private NativeEvent onGameOver;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            onGameOver.Invoke();
    }
}
