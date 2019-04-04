using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Rigidbody rb;

    public float fowardForce = 2000f;
    public float sideWayForce = 100f;
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = true;
        //rb.AddForce(0, 200, 800);
    }

    // Update is called once per frame
    void Update()
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
