using UnityEngine;
using Unity.Netcode;

public static class SpawnPointsHelper
{
    public static void ServerRespawnPlayers(int w, int h, float cellSize)
    {
        var ids = NetworkManager.Singleton.ConnectedClientsIds;
        if (ids.Count < 1) return;
        
        var p1 = GridToWorld(new Vector2Int(0, 0), cellSize);
        var p2 = GridToWorld(new Vector2Int(w - 1, h - 1), cellSize);

        var idx = 0;
        foreach (var id in ids)
        {
            var client = NetworkManager.Singleton.ConnectedClients[id];
            var playerObj = client.PlayerObject;
            if (playerObj)
            {
                playerObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                playerObj.transform.position = (idx == 0 ? p1 : p2) + Vector3.up * 0.5f;
            }
            idx++;
        }
    }
    
    static Vector3 GridToWorld(Vector2Int g, float size) => new Vector3(g.x * size, 0, g.y * size);
}