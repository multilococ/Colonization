using UnityEngine;

public class FlagPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _groundPosition;

    public void Placement(Vector3 screenPosition,Transform flag)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
        {
            _groundPosition = hitInfo.point;
        }

        flag.position = _groundPosition;
    }
}