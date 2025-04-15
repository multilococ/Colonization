using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class ResourcesGrabber : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private GameResource _grabbedResource;
    private BoxCollider _grabCollider;

    private bool _hasResource;

    public event Action Grabbed;

    public bool HasResource => _hasResource;

    public GameResource GrabbedResource => _grabbedResource;

    private void Awake()
    {
        _grabCollider = GetComponent<BoxCollider>();
        DisableGraberCollider();
        _hasResource = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out GameResource gameResource))
        {
            if (_hasResource == false)
            {
                Grabbed?.Invoke();
                _hasResource = true;
                _grabbedResource = gameResource;
                PutResourceInContainer();
            }
        }
    }

    public GameResource GetResource() 
    {
        GameResource resource = _grabbedResource;
        
        _grabbedResource = null;
        _hasResource = false;
        _container.DetachChildren();

        return resource;
    }

    public void EnableGraberCollider() 
    {
        _grabCollider.enabled = true;
    }

    public void DisableGraberCollider() 
    {
        _grabCollider.enabled = false;
    }

    private void PutResourceInContainer()
    {
        if (_grabbedResource != null)
        {
            _grabbedResource.transform.position = _container.position;
            _grabbedResource.transform.parent = _container.transform;
            _grabbedResource.transform.rotation = transform.rotation;
        }
    }
}
