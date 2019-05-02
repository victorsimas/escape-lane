using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fowardForce = 1000f;
    public float sideWayForce = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideWayForce, 0, 0 * Time.deltaTime);
        }
       if (Input.GetKey("a"))
        {
            rb.AddForce(-sideWayForce, 0, 0 * Time.deltaTime);
        }
    }
}
