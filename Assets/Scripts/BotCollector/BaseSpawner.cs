using System;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] private MilitaryBase _basePrefab;

    public event Action Created;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Flag flag))
        {
            SpawnBase(flag.transform.position);
        }
    }

    private void SpawnBase(Vector3 basePosition)
    {
        MilitaryBase militaryBase = Instantiate(_basePrefab, basePosition, Quaternion.identity);

       // militaryBase.AcceptBot(this);
       // _freeBot = null;
        Created?.Invoke();
    }
}
