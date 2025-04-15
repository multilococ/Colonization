using System;
using System.Collections;
using UnityEngine;

public class BotCollector : MonoBehaviour
{
    [SerializeField] private ResourcesGrabber _resourcesGrabber;
    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotHomePoint _homePoint;
    [SerializeField] private BaseSpawner _spawner;

    private ITarget _currentTarget;

    private bool _isAvaliable;

    public event Action BaseCreated;

    public bool IsAvaliable => _isAvaliable;

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
        if (_isAvaliable == true || target != null)
        {
            _currentTarget = target;
            _isAvaliable = false;
            StartCoroutine(MoveToTarget(_currentTarget));
        }
    }

    public void SetHomePoint(BotHomePoint botHomePoint)
    {
        _homePoint = botHomePoint;

        if (_homePoint != null)
            _homePoint.Occupy();
    }

    public void ReleaseHomePoint()
    {
        if (_homePoint != null)
            _homePoint.Release();
    }

    public void SpawnBase(Vector3 basePositon)
    {
        _spawner.Spawn(basePositon, this);
        BaseCreated?.Invoke();
    }

    public void EnableGraber()
    {
        _resourcesGrabber.EnableGraberCollider();
    }

    public void DisableGraber()
    {
        _resourcesGrabber.DisableGraberCollider();
    }

    public void ReturnToHome()
    {
        if (_homePoint != null)
        {
            GoTo(_homePoint);
        }
    }
   
    private IEnumerator MoveToTarget(ITarget target)
    {
        _botMover.SetTarget(target);

        while (_botMover.HasTarget)
            yield return null;

        if (_currentTarget == null)
            yield break;

        ITargetStrategy targetStrategy = null;

        switch (_currentTarget)
        {
            case BotHomePoint:
                targetStrategy = new HomePointStrategy();
                break;

            case GameResource:
                targetStrategy = new ResourceStrategy();
                break;

            case Flag:
                targetStrategy = new BaseSpawnerStrategy();
                break;
        }

        if (targetStrategy != null)
        {
            targetStrategy.ArrivedOnTarget(this);
            _isAvaliable = true;
        }

        _currentTarget = null;
    }
}