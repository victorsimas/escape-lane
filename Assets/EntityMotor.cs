using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMotor : MonoBehaviour
{
    private Transform trnsfrm;
    private Rigidbody rgdbdy;
    private Vector3 fowardForce = new Vector3();
    private float velocity;

    private void Awake()
    {
        trnsfrm = gameObject.GetComponent<Transform>();
        rgdbdy = gameObject.GetComponent<Rigidbody>();
        velocity = Random.Range(5, 10);
        fowardForce.z = velocity;
    }

    private void Update()
    {
        rgdbdy.AddForce(fowardForce * Time.deltaTime, ForceMode.VelocityChange);
    }

}
