using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TransferZone : MonoBehaviour
{
    public event Action<GameResource> Transfered;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ResourcesGrabber resourcesGrabber))
        {
            if (resourcesGrabber.HasResource)
            {
                GameResource gameResource = resourcesGrabber.GetResource();
                Transfered?.Invoke(gameResource);
                gameResource.Reset();
            }
        }
    }
}
