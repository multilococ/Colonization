using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    [SerializeField] private List<BotCollector> _bots;

    public void SendTo(Transform target) 
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
}
