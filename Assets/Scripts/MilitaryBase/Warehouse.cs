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

    public int OilQuantity => _oilQuantity;
    public int SupplyQuantity => _supplyQuantity;
    public int WaterQuantity => _waterQuantity;

    private void OnEnable()
    {
        _transferZone.Transfered += PickUp;
    }

    private void OnDisable()
    {
        _transferZone.Transfered -= PickUp;
    }

    public bool Buy(int oilValue, int supplyValue, int waterValue) 
    {
        bool successfully = false;

        if (InspectEnoughResources(oilValue,supplyValue,waterValue))
        { 
            successfully = true;
            _oilQuantity -= oilValue;
            _supplyQuantity -= supplyValue;
            _waterQuantity -= waterValue;

            OilQuantityChanged?.Invoke(_oilQuantity);
            SupplyQuantityChanged?.Invoke(_supplyQuantity);
            WaterQuantityChanged?.Invoke(_waterQuantity);
        }

        return successfully;
    }

    public bool InspectEnoughResources(int oilValue, int supplyValue, int waterValue)
    {
        bool isEnough = false;

        if (OilQuantity >= oilValue && WaterQuantity >= waterValue && SupplyQuantity >= supplyValue)
            isEnough = true;

        return isEnough;
    }

    private void PickUp(GameResource gameResource)
    {
        if (gameResource.Quantity > 0)
        {
            if (gameResource.ResourceType == ResourceType.Oil)
            {
                _oilQuantity += gameResource.Quantity;
                OilQuantityChanged?.Invoke(_oilQuantity);
            }
            else if (gameResource.ResourceType == ResourceType.Supply)
            {
                _supplyQuantity += gameResource.Quantity;
                SupplyQuantityChanged?.Invoke(_supplyQuantity);
            }
            else if (gameResource.ResourceType == ResourceType.Water)
            {
                _waterQuantity += gameResource.Quantity;
                WaterQuantityChanged?.Invoke(_waterQuantity);
            }
        }
    }
}