using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollector : MonoBehaviour
{
    [SerializeField] private ResourcesGrabber _resourcesGrabber;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotHomePoint _homePoint;
    [SerializeField] private BaseSpawner _spawner;

    private ITarget _currentTarget;
    private bool _isAvaliable;

    private readonly Dictionary<Type, ITargetStrategy> _strategies = new Dictionary<Type, ITargetStrategy>
    {
        { typeof(Flag), new SpawnBaseStrategy() },
        { typeof(BotHomePoint), new HomePointStrategy() },
        { typeof(GameResource), new ResourceStrategy() }
    };

    public event Action BaseCreated;

    public bool IsAvaliable => _isAvaliable;
    
    public ResourcesGrabber ResourcesGrabber => _resourcesGrabber;

    private void Awake()
    {
        _isAvaliable = true;

        if (_homePoint != null)
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

    public void GoTo(ITarget target)
    {
        if (!_isAvaliable || target == null)
            return;

        _currentTarget = target;
        _isAvaliable = false;

        StartCoroutine(GoToTarget());
    }

    private IEnumerator GoToTarget()
    {
        _botMover.SetTarget(_currentTarget.Transform);

        while (_botMover.HasTarget())
        {
            yield return null;
        }

        if (_currentTarget == null)
            yield break;
        
        Type targetType = _currentTarget.GetType();
        
        if (_strategies.TryGetValue(targetType, out ITargetStrategy strategy))
        {
            strategy.OnTargetReached(this);
        }

        _currentTarget = null;
    }

    public void SetHomePoint(BotHomePoint botHomePoint)
    {
        _homePoint = botHomePoint;
        if (_homePoint != null)
        {
            _homePoint.Occupy();
        }
    }

    public void ReleaseHomePoint()
    {
        if (_homePoint != null)
        {
            _homePoint.Release();
        }
    }

    public void SpawnBase(Vector3 basePosition)
    {
        _spawner.Spawn(basePosition, this);
        BaseCreated?.Invoke();
    }

    public void SetAvailable(bool isAvailable)
    {
        _isAvaliable = isAvailable;
    }

    private void ReturnToHome()
    {
        if (_homePoint != null)
        {
            GoTo(_homePoint);
        }
    }
}