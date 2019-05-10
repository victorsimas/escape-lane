using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public FloorSpawn floor;
    public int counterFloor;
    public bool floorRun;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        counterFloor = floor.GetComponent<FloorSpawn>().counter;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
        if (collision.collider.tag == "Floor" + counterFloor){
            floorRun = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor" + counterFloor)
        {
            floorRun = false;
        }
    }
}
