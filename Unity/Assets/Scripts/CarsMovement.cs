using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    private bool run;

    private Transform trnsfrm;
    private Rigidbody rgdbdy;
    private Vector3 fowardForce = new Vector3();
    private float velocity;

    private void Awake()
    {
        trnsfrm = gameObject.GetComponent<Transform>();
        rgdbdy = gameObject.GetComponent<Rigidbody>();
        velocity = Random.Range(12, 14);
        fowardForce.z = velocity;
    }

    private void Update()
    {
        if (PlayerMotor.Instance.IsRunning == true)
        {
            run = true;

            if (run != false)
            {
                rgdbdy.AddForce(fowardForce * Time.deltaTime, ForceMode.VelocityChange);
            }
            else
            {
                return;
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            run = false;
        }
    }
}
