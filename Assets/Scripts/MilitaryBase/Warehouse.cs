using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private TransferZone _transferZone;

    private int _oilQuantity = 0;
    private int _supplyQuantity = 0;
    private int _waterQuantity = 0;

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
        if (gameResource is OilResource)
            _oilQuantity += gameResource.Quantity;
        else if (gameResource is SupplyResource)
            _supplyQuantity += gameResource.Quantity;
        else if (gameResource is WaterResource)
            _waterQuantity += gameResource.Quantity;

        ShowResourceDebugInfo();
    }

    private void ShowResourceDebugInfo()
    {
        Debug.Log("OilCount = " + _oilQuantity);
        Debug.Log("supplyCount = " + _supplyQuantity);
        Debug.Log("waterCount = " + _waterQuantity);
    }
}