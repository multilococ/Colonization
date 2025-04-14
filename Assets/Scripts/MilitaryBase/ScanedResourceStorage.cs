using System.Collections.Generic;
using UnityEngine;

public class ScanedResourceStorage : MonoBehaviour
{
    [SerializeField] private List<GameResource> _scanedRosources;

    private void Awake()
    {
        _scanedRosources = new List<GameResource>();
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
        }

        return gameResource;
    }
}
