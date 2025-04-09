using UnityEngine;

public class BotCollector : MonoBehaviour
{
    [SerializeField] private ResourcesGrabber _resourcesGrabber;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private Transform _home;

    [SerializeField] private Transform _target;

    private bool _isAvaliable;

    public bool IsAvaliable => _isAvaliable;

    private void Awake()
    {
        _isAvaliable = true;
    }

    private void Start()
    {
        GoTo(_target);
    }

    private void OnEnable()
    {
        _resourcesGrabber.Grabbed += ReturnToHome;
    }

    private void OnDisable()
    {
        _resourcesGrabber.Grabbed -= ReturnToHome;
    }

    public void GoTo(Transform target) 
    {
        _target = target;
        _botMover.SetTarget(_target);
        _isAvaliable = false;
    }

    private void ReturnToHome() 
    {
        _botMover.SetTarget(_home);
    }
}