using UnityEngine;

public class MilitaryBase : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Barracks _barracks;
    [SerializeField] private ResourceScanner _resourceScanner;

    private void Start()
    {
        _resourceScanner.ScanTerritory();
    }
}
