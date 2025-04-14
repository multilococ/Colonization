using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private ScanedResourceStorage _scanedResourceStorage;
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private float _range;

    public void ScanTerritory()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _range, _resourceMask);

        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                if (hit.TryGetComponent(out GameResource gameResource))
                {
                    if (gameResource.IsDetected == false)
                    {
                        gameResource.Detect();
                        _scanedResourceStorage.Add(gameResource);
                    }
                }
            }
        }
    }
}