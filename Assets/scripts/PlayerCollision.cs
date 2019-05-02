using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "barrier")
        {
            movement.enabled = false;
        }
    }
}
