using System;
using UnityEngine;

public class BotCollector : MonoBehaviour
{
    [SerializeField] private ResourcesGrabber _resourcesGrabber;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotHomePoint _homePoint;
    [SerializeField] private BaseSpawner _spawner;

    private Transform _target;

    private float _minDistance = 0.1f;

    private bool _isAvaliable;

    public event Action<Vector3> Arrived;
    public event Action BaseCreated;

    public bool IsAvaliable => _isAvaliable;

    private void Awake()
    {
        _isAvaliable = true;

        if(_homePoint != null)
        {
            _homePoint.Occupy();
        }
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
                if (_target != _homePoint.transform)
                {
                    Arrived?.Invoke(transform.position);
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

    public void SetHomePoint(BotHomePoint botHomePoint) 
    {
        _homePoint = botHomePoint;
        _homePoint.Occupy();
    }

    public void ReleaseHomePoint() 
    {
        _homePoint.Release();
    }

    public void SpawnBase(Vector3 basePositon) 
    {
        Arrived -= SpawnBase;
        _spawner.Spawn(basePositon, this);
        BaseCreated?.Invoke();
    }

    private void ReturnToHome()
    {
        _target = _homePoint.transform;
        _botMover.SetTarget(_homePoint.transform);
    }
}