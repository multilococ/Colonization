using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class GameResource : MonoBehaviour
{
    private int _quantity;
    private int _maxQuantity = 10;
    private int _minQuantity = 1;

    private bool _isGrabed;
    private bool _isScaned;

    public int Quantity => _quantity;

    public bool IsGrabed => _isGrabed;
    public bool IsScaned => _isScaned;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _quantity = Random.Range(_minQuantity, _maxQuantity);
        _isGrabed = false;
        _isScaned = false;
    }

    public void Scan() 
    {
        _isScaned = true;
    }

    public void Grabb() 
    {
        _isGrabed = true;
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}