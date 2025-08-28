using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRevealController : MonoBehaviour
{
    public GridManager grid;
    public LayerMask tileLayer = ~0;

    void Update()
    {
        if (!GameManager.Instance || GameManager.Instance.state.Value != GameState.Playing) return;
        if (!GameManager.Instance.IsMyTurn) return;

        if (EventSystem.current && EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            var cam = Camera.main;
            if (!cam) return;

            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, tileLayer))
            {
                var cell = hit.collider.GetComponent<TileCell>();
                if (cell)
                {
                    var myId = NetworkManager.Singleton.LocalClientId;
                    grid.TryRevealServerRpc(cell.GridPos, myId);
                }
            }
        }
    }
}