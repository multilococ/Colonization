using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] private MilitaryBase _basePrefab;
   
    public void Spawn(Vector3 basePosition,BotCollector botCollector)
    {
        MilitaryBase militaryBase = Instantiate(_basePrefab, basePosition, Quaternion.identity);

        militaryBase.AcceptBot(botCollector);
    }
}
