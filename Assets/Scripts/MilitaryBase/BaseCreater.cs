using System;
using UnityEngine;

public class BaseCreater : MonoBehaviour
{
    [SerializeField] private MilitaryBase _basePrefab;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Barracks _barracks;

    private BotCollector _freeBot;

    private int _oilPrice = 5;
    private int _waterPrice = 5;
    private int _supplyPrice = 5;

    public event Action Created;

    public void SendFreeBotTo(Transform point) 
    {
        if (_warehouse.InspectEnoughResources(_oilPrice, _supplyPrice, _waterPrice) && _barracks.InspectFreeBots())
        {
            _warehouse.Buy(_oilPrice, _supplyPrice, _waterPrice);

            _freeBot = _barracks.GetBot();

            _freeBot.GoTo(point);
            _freeBot.Arrived += CreateNewBase;
        }
    }

    private void CreateNewBase(Vector3 basePosition) 
    {
        _freeBot.Arrived -= CreateNewBase;

        MilitaryBase militaryBase = Instantiate(_basePrefab, basePosition, Quaternion.identity);

        militaryBase.AcceptBot(_freeBot);
        _freeBot = null;
        Created?.Invoke();
    }
}
