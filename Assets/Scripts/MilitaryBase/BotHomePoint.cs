using UnityEngine;

public class BotHomePoint : MonoBehaviour, ITarget
{
    [SerializeField] private bool _isFree;

    public Transform Transform => transform;

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
