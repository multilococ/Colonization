using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    
    private Transform _target;

    private void Update()
    {
        if (_target != null)
            MoveTo();
    }

    public void SetTarget(Transform target) 
    {
        _target = target;
    }

    private void MoveTo()
    {
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}