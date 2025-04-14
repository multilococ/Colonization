using System.Collections;
using UnityEngine;

public class MilitaryBase : MonoBehaviour
{
    [SerializeField] private Barracks _barracks;
    [SerializeField] private ResourceScanner _resourceScanner;
    [SerializeField] private BotCreator _botCreater;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private BaseCreator _baseCreaterSender;
    [SerializeField] private ScanedResourceStorage _scanedResourceStorage;
    [SerializeField] private Flag _flag;
    [SerializeField] private FlagInstaller _flagInstaller;
    [SerializeField] private float _scanDelay = 3f;

    private float _workDelay = 1f;

    private void Start()
    {
        StartCoroutine(Scan());
        StartCoroutine(Work());
    }

    private void OnEnable()
    {
        _baseCreaterSender.Created += _flagInstaller.Disable;
    }

    private void OnDisable()
    {
        _baseCreaterSender.Created -= _flagInstaller.Disable;
    }

    public void AcceptBot(BotCollector botCollector)
    {
        _barracks.AddBot(botCollector);
    }

    private IEnumerator Work()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_workDelay);

        while (enabled)
        {
            yield return waitForSeconds;

            CollectResource();

            if (_flagInstaller.Instaled == true && _barracks.BotsCount > 1)
            {
                _baseCreaterSender.SendFreeBotTo(_flag.transform);
            }
            else
            {
                CreateNewBot();
            }
        }
    }

    private IEnumerator Scan()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_scanDelay);

        while (enabled)
        {
            yield return waitForSeconds;

            _resourceScanner.ScanTerritory();
        }
    }

    private void CreateNewBot()
    {
        if (_botCreater.InspectFreeHomePoints())
        {
            BotCollector newBot = _botCreater.CreateNewBot();

            if (newBot != null)
            {
                _barracks.AddBot(newBot);
            }
        }
    }

    private void CollectResource()
    {
        if (_barracks.InspectFreeBots())
        {
            GameResource freeResource = _scanedResourceStorage.GetFirstResource();

            if (freeResource != null)
                _barracks.SendFreeBotTo(freeResource.transform);
        }
    }
}