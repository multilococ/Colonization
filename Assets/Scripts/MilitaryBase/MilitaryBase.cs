using UnityEngine;

public class MilitaryBase : MonoBehaviour
{
    [SerializeField] private Barracks _barracks;
    [SerializeField] private ResourceScanner _resourceScanner;

    public void GetResource() 
    {
        if (_barracks.CheckFreeBots())
        {
            GameResource freeResource = _resourceScanner.GetResource();

            if (freeResource != null)
                _barracks.SendFreeBotTo(freeResource.transform);
        }
    }
}