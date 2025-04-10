using UnityEngine;
using UnityEngine.UI;

public class ScanerButton : MonoBehaviour
{
    [SerializeField] private ResourceScanner _resourceScanner;
    [SerializeField] private Button _scanerButton;

    private void OnEnable()
    {
        _scanerButton.onClick.AddListener(_resourceScanner.ScanTerritory);
        _resourceScanner.GhangeAvailiable += SetInteractable;
    }

    private void OnDisable()
    {
        _scanerButton.onClick.RemoveListener(_resourceScanner.ScanTerritory);        
        _resourceScanner.GhangeAvailiable -= SetInteractable;
    }

    private void SetInteractable(bool isAvailiable) 
    {
        _scanerButton.interactable = isAvailiable;
    }
}
