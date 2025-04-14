using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    [SerializeField] private List<BotCollector> _bots;
    [SerializeField] private List<BotHomePoint> _botHomePoints;

    public int BotsCount => _bots.Count;

    public void SendFreeBotTo(ITarget target) 
    {
        foreach (BotCollector bot in _bots) 
        {
            if (bot.IsAvaliable)
            {
                bot.GoTo(target);

                break;
            }
        }
    }

    public bool InspectFreeBots() 
    {
        foreach (BotCollector bot in _bots)
        {
            if (bot.IsAvaliable)
            {
                return true;
            }
        }

        return false;
    }

    public void AddBot(BotCollector botCollector)
    {
        foreach (BotHomePoint homePoint in _botHomePoints)
        {
            if (homePoint.IsFree)
            {
                _bots.Add(botCollector);
                botCollector.SetHomePoint(homePoint);
                botCollector.GoTo(homePoint);
                homePoint.Occupy();

                break;
            }
        }
    }

    public BotCollector GetBot() 
    {
        BotCollector botCollector = null;

        foreach(BotCollector bot in _bots) 
        {
            if (bot.IsAvaliable)
            {
                botCollector = bot;
            }
        }

        _bots.Remove(botCollector);
        botCollector?.ReleaseHomePoint();

        return botCollector;
    }
}
