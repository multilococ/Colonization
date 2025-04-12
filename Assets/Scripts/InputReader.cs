using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Vector3 _mousePosition;

    public event Action RightMouseButtonClicked;
 
    public Vector3 MousePosition => _mousePosition;

    private void Update()
    {
        _mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(1))
        { 
            RightMouseButtonClicked?.Invoke();
        }
    }
}
