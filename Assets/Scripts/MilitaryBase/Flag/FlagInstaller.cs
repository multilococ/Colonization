using UnityEngine;

public class FlagInstaller : MonoBehaviour
{
    [SerializeField] private Flag _flag;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private FlagPlacer _placer;
   
    private bool _isEnabled;

    private bool _instaled;

    public bool Instaled => _instaled;
    private void Awake()
    {
        _instaled = false;
        Disable();
    }

    private void OnEnable()
    {
        _inputReader.RightMouseButtonClicked += Instal;
    }

    private void OnDisable()
    {
        _inputReader.RightMouseButtonClicked -= Instal;
    }

    private void Update()
    {
        if (_isEnabled)
        {
            _placer.Placement(_inputReader.MousePosition, _flag.transform); 
        }
    }

    public void Disable() 
    {
        _isEnabled = false;
        _flag.gameObject.SetActive(false);
        _instaled = false;
    }

    public void Switch()
    {
        if (_isEnabled == false)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }
   
    private void Instal() 
    {
        if (_isEnabled)
        {
            _isEnabled = false;
            _instaled = true;
        }
    }

    private void Enable() 
    {
        _isEnabled = true;
        _flag.gameObject.SetActive(true);
    }
}