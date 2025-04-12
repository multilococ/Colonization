using System.Collections.Generic;
using UnityEngine;

public class BotCreater : MonoBehaviour
{
    [SerializeField] private BotCollector _botPrefab;
    [SerializeField] private List<BotHomePoint> _botHomePoints;
    [SerializeField] private Warehouse _warehouse;

    private int _oilPrice = 1;
    private int _waterPrice = 1;
    private int _supplyPrice = 1;

    public BotCollector CreateNewBot()
    {
        BotCollector newBot = null;

        if (InspectFreeHomePoints())
        {
            BotHomePoint freePoint = GetFreeHomePoint();

            if (freePoint != null)
            {
                if (_warehouse.Buy(_oilPrice,_supplyPrice,_waterPrice))
                {
                    newBot = Instantiate(_botPrefab, freePoint.transform.position, Quaternion.identity);
                }
            }
        }

        return newBot;
    }

    public bool InspectFreeHomePoints()
    {
        bool hasFreePoint = false;

        foreach (BotHomePoint botHomePoint in _botHomePoints)
        {
            if (botHomePoint.IsFree)
            {
                hasFreePoint = true;

                break;
            }
        }

        return hasFreePoint;
    }

    private BotHomePoint GetFreeHomePoint()
    {
        BotHomePoint homePoint = null;

        foreach (BotHomePoint botHomePoint in _botHomePoints)
        {
            if (botHomePoint.IsFree)
            {
                homePoint = botHomePoint;

                break;
            }
        }

        return homePoint;
    }
}