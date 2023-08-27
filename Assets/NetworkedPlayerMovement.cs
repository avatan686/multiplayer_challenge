using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 1000.0f;
    private Vector3 movement;

    public override void OnNetworkSpawn()
    {
        // Don't try to control other players' avatars
        if (!IsOwner)
        {
            GetComponent<PlayerInput>().enabled = false;
        }
    }

    private void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        AskToMoveServerRpc(inputVec);
    }

    [ServerRpc]
    void AskToMoveServerRpc(Vector2 inputVec)
    {
        movement = new Vector3(inputVec.x, 0, inputVec.y);
    }

    private void FixedUpdate()
    {
        if (!IsServer) return;

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(movement * Time.fixedDeltaTime * speed);
    }
}
