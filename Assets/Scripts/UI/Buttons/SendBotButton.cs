using UnityEngine;
using UnityEngine.UI;

public class SendBotButton : MonoBehaviour
{
    [SerializeField] private MilitaryBase _militaryBase;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(_militaryBase.GetResource);        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_militaryBase.GetResource);
    }
}
