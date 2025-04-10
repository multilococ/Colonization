using TMPro;
using UnityEngine;

public class WarehouseView : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    
    [SerializeField] private TextMeshProUGUI _oilQuantityText;
    [SerializeField] private TextMeshProUGUI _supplyQuantityText;
    [SerializeField] private TextMeshProUGUI _waterQuantityText;

    private void OnEnable()
    {
        _warehouse.OilQuantityChanged += ChageOilText;
        _warehouse.SupplyQuantityChanged += ChageSupplyText;
        _warehouse.WaterQuantityChanged += ChageWaterText;
    }

    private void OnDisable()
    {
        _warehouse.OilQuantityChanged -= ChageOilText;
        _warehouse.SupplyQuantityChanged -= ChageSupplyText;
        _warehouse.WaterQuantityChanged -= ChageWaterText;
    }

    private void ChageOilText(int value) 
    {
        _oilQuantityText.text = value.ToString();
    }
    
    private void ChageSupplyText(int value)
    {
        _supplyQuantityText.text = value.ToString();
    }

    private void ChageWaterText(int value)
    {
        _waterQuantityText.text = value.ToString();
    }
}
