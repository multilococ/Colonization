using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = _mainCamera.transform.rotation;
    }
}
