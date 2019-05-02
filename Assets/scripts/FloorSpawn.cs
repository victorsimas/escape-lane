using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public Transform floor;

    private void Start()
    {
        floor = GetComponent<Transform>();
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && collision.collider.transform.position.z  >= floor.position.z)
        {
            Debug.Log("beyond floor");
        }
    }

    private void FixedUpdate()
    {
        
    }
}
