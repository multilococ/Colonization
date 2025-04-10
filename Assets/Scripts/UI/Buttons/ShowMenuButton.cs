using UnityEngine;
using UnityEngine.UI;

public class ShowMenuButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _menyPanel;

    private bool _isShowed;

    private void Awake()
    {
        HideMenu();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Switch);   
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Switch);
    }

    private void Switch() 
    {
        if (_isShowed == false)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }
    }

    private void HideMenu()
    {
        _menyPanel.interactable = false;
        _menyPanel.alpha = 0f;
        _isShowed = false;
    }

    private void ShowMenu()
    {
        _menyPanel.interactable = true;
        _menyPanel.alpha = 1f;
        _isShowed = true;
    }
}
