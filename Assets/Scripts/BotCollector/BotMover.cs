using System.Collections;
using UnityEngine;

public class BotMover : MonoBehaviour
{
  [SerializeField] private float _speed = 10f;
  [SerializeField] private float _minDistance = 0.1f;

  private ITarget _target;
  private Coroutine _moveCoroutine;

  public void SetTarget(ITarget target)
  {
    _target = target;

    if (_moveCoroutine != null)
    {
      StopCoroutine(_moveCoroutine);
    }

    if (_target != null)
    {
      _moveCoroutine = StartCoroutine(MoveToTarget());
    }
  }

  public bool HasTarget()
  {
    return _target != null;
  }

  private IEnumerator MoveToTarget()
  {
    while (_target != null)
    {
      if (transform.position.IsEnoughClose(_target.Transform.position, _minDistance))
      {
        _target = null;
        yield break;
      }

      transform.LookAt(_target.Transform);
      transform.position = Vector3.MoveTowards(transform.position, _target.Transform.position, _speed * Time.deltaTime);

      yield return null;
    }
  }
}