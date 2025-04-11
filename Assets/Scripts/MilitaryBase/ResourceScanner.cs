using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private List<GameResource> _scanedResources;
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private float _range;

    public GameResource GetResource()
    {
        GameResource gameResource = null;

        if (_scanedResources.Count > 0)
        {
            gameResource = _scanedResources[0];
            _scanedResources.Remove(gameResource);
        }

        return gameResource;
    }

    public void ScanTerritory()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _range, _resourceMask);

        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (hit.TryGetComponent(out GameResource gameResource))
                {
                    if (gameResource.IsDtetected == false)
                    {
                        gameResource.Detect();
                        _scanedResources.Add(gameResource);
                    }
                }
            }
        }
    }
}