using UnityEngine;
using Unity.Netcode;

public class Health : NetworkBehaviour
{
    private const int MaxHits = 5;
    private NetworkVariable<int> hits = new NetworkVariable<int>();

    public void TakeHit()
    {
        if (IsServer)
        {
            hits.Value += 1;
            if (hits.Value >= MaxHits)
            {
                // Respawn the player
                Respawn();
            }
        }
    }

    private void Respawn()
    {
        // Implement respawn logic
        hits.Value = 0;
        // Reposition the player to the respawn location
    }

    [ServerRpc]
    public void AddScoreServerRpc(int playerId, int scoreToAdd)
    {
        // Implement logic to add score
    }
}
