using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private NativeEvent onImageSelected;

    [SerializeField]
    private int gameSceneIndex = 1;

    public void Play()
    {
        onImageSelected.Invoke();
        SceneManager.LoadScene(gameSceneIndex);
    }
}
