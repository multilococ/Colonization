using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class ResourcesGrabber : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private GameResource _grabbedResource;
    private bool _hasResource;
    public bool HasResource => _hasResource;

    public event Action Grabbed;

    private void Awake()
    {
        _hasResource = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out GameResource gameResource))
        {
            if (gameResource.IsGrabed == false && _hasResource == false)
            {
                Grabbed?.Invoke();
                _hasResource = true;
                _grabbedResource = gameResource;
                gameResource.Grabb();
                PutInContainer();
            }
        }
    }

    public GameResource GetResource() 
    {
        _hasResource = false;
        _container.DetachChildren();

        return _grabbedResource;
    }

    private void PutInContainer()
    {
        if (_grabbedResource != null)
        {
            _grabbedResource.transform.position = _container.position;
            _grabbedResource.transform.parent = _container.transform;
            _grabbedResource.transform.rotation = transform.rotation;
        }
    }
}
