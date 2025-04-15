using System.Collections;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    
    private float _minDistance = 0.1f;

    private ITarget _target;
    
    private Coroutine _coroutine;

    public bool HasTarget => _target != null;

    public void SetTarget(ITarget target)
    {
        _target = target;
        
        if (_coroutine != null)
        {
            StopCoroutine(MoveToTarget());
        }

        if (_target != null) 
        {
            _coroutine = StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (_target != null)
        {
            if (transform.position.IsEnoughClose(_target.Position, _minDistance))
            {
                _target = null;

                yield break;
            }
            
            transform.LookAt(_target.Position);
            transform.position = Vector3.MoveTowards(transform.position, _target.Position, _speed * Time.deltaTime);

            yield return null;
        }
    }
}