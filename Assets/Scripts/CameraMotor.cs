using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 offset = new Vector3(21f, 5.4f, -8f);

    private void Start()
    {
        lookAt = GameObject.FindWithTag("Player").transform;
    }

    public void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}
