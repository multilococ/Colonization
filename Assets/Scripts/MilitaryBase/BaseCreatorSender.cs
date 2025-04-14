using System;
using UnityEngine;

public class BaseCreatorSender : MonoBehaviour
{
  [SerializeField] private Warehouse _warehouse;
  [SerializeField] private Barracks _barracks;

  private BotCollector _freeBot;

  private int _oilPrice = 5;
  private int _waterPrice = 5;
  private int _supplyPrice = 5;

  public event Action Created;

  public void SendFreeBotTo(ITarget point)
  {
    if (_warehouse.InspectEnoughResources(_oilPrice, _supplyPrice, _waterPrice) && _barracks.InspectFreeBots() && _freeBot == null)
    {
      _warehouse.Buy(_oilPrice, _supplyPrice, _waterPrice);

      _freeBot = _barracks.GetBot();

      _freeBot.GoTo(point);
      _freeBot.BaseCreated += ReleaseBot;
    }
  }

  private void ReleaseBot()
  {
    _freeBot.BaseCreated -= ReleaseBot;
    _freeBot = null;
    Created?.Invoke();
  }
}