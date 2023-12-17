using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        if (IsLocalPlayer && Input.GetButtonDown("Fire1"))
        {
            FireProjectileServerRpc();
        }
    }

    [ServerRpc]
    void FireProjectileServerRpc()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        NetworkObject networkObject = projectile.GetComponent<NetworkObject>();
        networkObject.Spawn();
        // Apply force to the projectile if needed
    }
}
