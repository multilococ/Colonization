using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TransferZone : MonoBehaviour
{
    [SerializeField] private ScanedResourceStorage _resourceStorage;

    public event Action<GameResource> Transfered;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ResourcesGrabber resourcesGrabber))
        {
            if (resourcesGrabber.HasResource)
            {
                if (_resourceStorage.TryVerifyResource(resourcesGrabber.GrabbedResource))
                {
                    GameResource gameResource = resourcesGrabber.GetResource();

                    Transfered?.Invoke(gameResource);
                    gameResource.Reset();
                }
            }
        }
    }
}
