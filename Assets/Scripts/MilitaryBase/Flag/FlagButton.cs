using UnityEngine;
using UnityEngine.UI;

public class FlagButton : MonoBehaviour
{
    [SerializeField] private FlagInstaller _flagInstaller;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(_flagInstaller.Switch);   
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_flagInstaller.Switch);
    }
}
