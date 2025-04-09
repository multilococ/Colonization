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

    private void Awake()
    {
        _isAvailiable = true;
        _waitForSeconds = new WaitForSeconds(_reloadTime);
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
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() 
    {
        yield return _waitForSeconds;

        _isAvailiable = true;
    }
}