using UnityEngine;

public class BotCollector : MonoBehaviour
{
    [SerializeField] private ResourcesGrabber _resourcesGrabber;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private Transform _home;

    private Transform _target;

    private float _minDistance = 0.1f;

    private bool _isAvaliable;

    public bool IsAvaliable => _isAvaliable;

    private void Awake()
    {
        _isAvaliable = true;
    }

    private void OnEnable()
    {
        _resourcesGrabber.Grabbed += ReturnToHome;
    }

    private void OnDisable()
    {
        _resourcesGrabber.Grabbed -= ReturnToHome;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (transform.position.IsEnoughClose(_target.position, _minDistance))
            {
                if (_target != _home)
                {
                    _resourcesGrabber.EnableGraberCollider();
                }
                else
                {
                    _isAvaliable = true;
                    _resourcesGrabber.DisableGraberCollider();
                }
            }
        }
    }

    public void GoTo(Transform target)
    {
        _target = target;
        _botMover.SetTarget(_target);
        _isAvaliable = false;
    }

    private void ReturnToHome()
    {
        _target = _home;
        _botMover.SetTarget(_home);
    }
}