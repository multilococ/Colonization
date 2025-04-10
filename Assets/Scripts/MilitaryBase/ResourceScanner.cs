using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private List<GameResource> _scanedResources;
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private float _range;
    [SerializeField] private float _reloadTime;

    private WaitForSeconds _waitForSeconds;

    private bool _isAvailiable;

    public event Action<bool> GhangeAvailiable;

    private void Awake()
    {
        _isAvailiable = true;
        GhangeAvailiable?.Invoke(_isAvailiable); 
        _waitForSeconds = new WaitForSeconds(_reloadTime);
    }

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
        if (_isAvailiable)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _range,_resourceMask);
           
            if (hits.Length > 0)
            {
                foreach (Collider hit in hits)
                {
                    if (hit.TryGetComponent(out GameResource gameResource))
                    {
                        if (gameResource.IsScaned == false)
                        {
                            gameResource.Scan();
                            _scanedResources.Add(gameResource);
                        }
                    }
                }
            }

            _isAvailiable = false;
            GhangeAvailiable?.Invoke(_isAvailiable);
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() 
    {
        yield return _waitForSeconds;

        _isAvailiable = true;
        GhangeAvailiable?.Invoke(_isAvailiable);
    }
}