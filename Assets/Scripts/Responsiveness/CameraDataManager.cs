using UnityEngine;
using System.Linq;
using NaughtyAttributes;
using System;

public class CameraDataManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField, ReorderableList, ShowIf("HasHandlers")]
    private CameraDataHandler[] handlers = new CameraDataHandler[1];

    private bool HasHandlers() => handlers.Length > 0;


    private void Awake()
    {
        CameraData cameraData = GetCameraData();

        foreach (var handler in handlers)
            handler.HandleCameraData(cameraData);
    }

    private CameraData GetCameraData()
    {
        float aspect = camera.aspect;
        float height = camera.orthographicSize * 2f;
        float width = aspect * height;

        return new CameraData(aspect, width, height);
    }


#if UNITY_EDITOR
    [Button("Find Handlers")]
    private void FindHanlders()
    {
        handlers = FindObjectsOfType<MonoBehaviour>().OfType<CameraDataHandler>().ToArray();
    }
#endif
}
