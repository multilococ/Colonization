using UnityEngine;

public class ResourceIconShower : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameResource _gameResource;

    private void OnEnable()
    {
        _gameResource.Detected += Switch;
    }

    private void OnDisable()
    {
        _gameResource.Detected -= Switch;   
    }

    private void Switch(bool isDetected) 
    {
        if (isDetected)
        {
            _canvasGroup.alpha = 1f;
        }
        else 
        {
            _canvasGroup.alpha = 0f;
        }
    }
}
