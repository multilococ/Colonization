using UnityEngine;

public class Flag : MonoBehaviour, ITarget
{
    public Vector3 Position => transform.position;
}
