using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class GameResource : MonoBehaviour
{
    private int _quantity;
    private int _maxQuantity = 3;
    private int _minQuantity = 1;

    private bool _isGrabed;
    private bool _isScaned;

    public int Quantity => _quantity;

    public bool IsGrabed => _isGrabed;
    public bool IsScaned => _isScaned;

    public event Action<bool> Detected;
    public event Action<GameResource> Died;

    public void Init(Vector3 spawmPosition)
    {
        transform.position = spawmPosition;
        _quantity = UnityEngine.Random.Range(_minQuantity, _maxQuantity);
        _isGrabed = false;
        _isScaned = false;
        Detected?.Invoke(false);
    }

    public void Scan() 
    {
        _isScaned = true;
        Detected?.Invoke(true);
    }

    public void Grabb() 
    {
        _isGrabed = true;
    }

    public void Reset()
    {
        Died?.Invoke(this);
    }
}