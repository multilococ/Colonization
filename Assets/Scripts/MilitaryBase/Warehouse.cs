using System;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private TransferZone _transferZone;

    private int _oilQuantity = 0;
    private int _supplyQuantity = 0;
    private int _waterQuantity = 0;

    public event Action<int> OilQuantityChanged;
    public event Action<int> SupplyQuantityChanged;
    public event Action<int> WaterQuantityChanged;

    private void OnEnable()
    {
        _transferZone.Transfered += PickUp;
    }

    private void OnDisable()
    {
        _transferZone.Transfered -= PickUp;
    }

    private void PickUp(GameResource gameResource)
    {
        if (gameResource.Quantity > 0)
        {
            if (gameResource is OilResource)
            {
                _oilQuantity += gameResource.Quantity;
                OilQuantityChanged?.Invoke(_oilQuantity);
            }
            else if (gameResource is SupplyResource)
            {
                _supplyQuantity += gameResource.Quantity;
                SupplyQuantityChanged?.Invoke(_supplyQuantity);
            }
            else if (gameResource is WaterResource)
            {
                _waterQuantity += gameResource.Quantity;
                WaterQuantityChanged?.Invoke(_waterQuantity);
            }
        }
    }
}