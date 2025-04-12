using System.Collections;
using UnityEngine;

public class MilitaryBase : MonoBehaviour
{
    [SerializeField] private Barracks _barracks;
    [SerializeField] private ResourceScanner _resourceScanner;
    [SerializeField] private BotCreater _botCreater;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private BaseCreater _baseCreater;
    [SerializeField] private ScanedResourceStorage _scanedResourceStorage;
    [SerializeField] private Flag _flag;
    [SerializeField] private FlagInstaller _flagInstaller;

    private float _workDelay = 1f;
    private float _scanDelay = 3f;

    private void Start()
    {
        StartCoroutine(Scan());
        StartCoroutine(Work());
    }

    private void OnEnable()
    {
        if (_flagInstaller != null)
            _baseCreater.Created += _flagInstaller.Disable;
    }

    private void OnDisable()
    {
        if (_flagInstaller != null)
            _baseCreater.Created -= _flagInstaller.Disable;
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

            if (_flagInstaller != null && _baseCreater != null)
            {
                if (_flagInstaller.Instaled == true)
                {
                    _baseCreater.SendFreeBotTo(_flag.transform);
                }
                else
                {       
                    CreateNewBot();
                }
            }
            else
            {
                CollectResource();
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