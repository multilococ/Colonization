using System.Collections.Generic;
using UnityEngine;

public class ScanedResourceStorage : MonoBehaviour
{
    [SerializeField] private List<GameResource> _scanedRosources;
   
    private List<GameResource> _expectedResources;

    private void Awake()
    {
        _scanedRosources = new List<GameResource>();
        _expectedResources = new List<GameResource>();
    }

    public void Add(GameResource gameResource) 
    {
        if(_scanedRosources.Contains(gameResource) == false)
             _scanedRosources.Add(gameResource);
    }

    public GameResource GetFirstResource() 
    {
        GameResource gameResource = null;

        if (_scanedRosources.Count > 0)
        {
            gameResource = _scanedRosources[0];
            _scanedRosources.Remove(gameResource);
            _expectedResources.Add(gameResource);
        }

        return gameResource;
    }

    public bool TryVerifyResource(GameResource gameResource) 
    {
        if (_expectedResources.Count > 0) 
        {
            if (_expectedResources.Contains(gameResource))
            {
                _expectedResources.Remove(gameResource);
                
                return true;
            }
        }

        return false;
    }  
}
