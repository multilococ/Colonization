using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class GameResource : MonoBehaviour
{
    private int _quantity;
    private int _maxQuantity = 3;
    private int _minQuantity = 1;

    private bool _isDetected;

    public event Action<bool> Detected;
    public event Action<GameResource> Reseted;

    public int Quantity => _quantity;

    public bool IsDtetected => _isDetected;

    public void Init(Vector3 spawmPosition)
    {
        transform.position = spawmPosition;
        _quantity = UnityEngine.Random.Range(_minQuantity, _maxQuantity);
        _isDetected = false;
        Detected?.Invoke(false);
    }

    public void Detect() 
    {
        _isDetected = true;
        Detected?.Invoke(true);
    }

    public void Reset()
    {
        Reseted?.Invoke(this);
    }
}