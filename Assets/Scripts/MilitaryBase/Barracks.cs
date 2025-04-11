using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    [SerializeField] private List<BotCollector> _bots;

    public void SendFreeBotTo(Transform target) 
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
}
