using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private GameResourcePool _pool;
    [SerializeField] private SpawnArea _spawnArea;  
    [SerializeField] private float _delay = 3f;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() 
    {
        while (enabled) 
        {
            yield return _waitForSeconds;

            _pool.SpawnResource(_spawnArea.GetRandomPosition());
        }
    }
}
