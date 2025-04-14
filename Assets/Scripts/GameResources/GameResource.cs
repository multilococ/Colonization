using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GameResource : MonoBehaviour, ITarget
{
   [SerializeField] private ResourceType _resourceType;

    private int _quantity;
    private int _maxQuantity = 3;
    private int _minQuantity = 1;

    private bool _isDetected;

    public event Action<bool> Detected;
    public event Action<GameResource> Reseted;

    public ResourceType ResourceType => _resourceType; 

    public int Quantity => _quantity;

    public bool IsDetected => _isDetected;

    public Transform Transform => transform;

    public void Init(Vector3 spawmPosition)
    {
        transform.position = spawmPosition;
        _quantity = UnityEngine.Random.Range(_minQuantity, _maxQuantity);
        _isDetected = false;
        Detected?.Invoke(_isDetected);
    }

    public void Detect() 
    {
        _isDetected = true;
        Detected?.Invoke(_isDetected);
    }

    public void Reset()
    {
        Reseted?.Invoke(this);
    }
}