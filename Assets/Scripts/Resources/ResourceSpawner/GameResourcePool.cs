using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameResourcePool : MonoBehaviour
{
    [SerializeField] private List<GameResource> _gameResourcesPrefabs;
    
    private ObjectPool<GameResource> _resourcePool;

    private int _poolCapacity = 10;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _resourcePool = CreatePool();
    }

    public void SpawnResource(Vector3 position) 
    {
        GameResource resource = _resourcePool.Get();

        resource.Init(position);
        resource.Died += ReleaseResource;
    }

    private ObjectPool<GameResource> CreatePool() 
    {
        return new ObjectPool<GameResource>(
            createFunc: () => Instantiate(GetRandomPrefab()),
            actionOnRelease: (resource) => resource.gameObject.SetActive(false),
            actionOnGet: (resource) => resource.gameObject.SetActive(true),
            actionOnDestroy: (resource) => Destroy(resource.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize) ;
    }

    private GameResource GetRandomPrefab() 
    {
        GameResource resource = null;

        if (_gameResourcesPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, _gameResourcesPrefabs.Count);
            
            resource = _gameResourcesPrefabs[randomIndex];
        }

        return resource;
    }

    private void ReleaseResource(GameResource resource) 
    {
        resource.Died -= ReleaseResource;
        _resourcePool.Release(resource);
    }
}
