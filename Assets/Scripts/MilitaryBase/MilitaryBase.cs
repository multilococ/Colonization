using System.Collections;
using UnityEngine;

public class MilitaryBase : MonoBehaviour
{
    [SerializeField] private Barracks _barracks;
    [SerializeField] private ResourceScanner _resourceScanner;

    private float _workDelay = 1f;

    private void Start()
    {
        StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_workDelay);

        while (enabled) 
        {
            yield return waitForSeconds;

            _resourceScanner.ScanTerritory();
            CollectResource();
        }
    }

    private void CollectResource() 
    {
        if (_barracks.InspectFreeBots())
        {
            GameResource freeResource = _resourceScanner.GetResource();

            if (freeResource != null)
                _barracks.SendFreeBotTo(freeResource.transform);
        }
    }
}