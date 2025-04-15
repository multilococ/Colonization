using UnityEngine;

public class BotHomePoint : MonoBehaviour,ITarget
{
    [SerializeField] private bool _isFree;

    public bool IsFree => _isFree;

    public Vector3 Position => transform.position;

    public void Occupy()
    {
        _isFree = false;
    }

    public void Release()
    {
        _isFree = true;
    }
}