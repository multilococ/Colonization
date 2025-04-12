using UnityEngine;

public class BotHomePoint : MonoBehaviour
{
    [SerializeField] private bool _isFree;

    public bool IsFree => _isFree;

    public void Occupy()
    {
        _isFree = false;
    }

    public void Release()
    {
        _isFree = true;
    }
}
