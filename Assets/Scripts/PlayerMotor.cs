using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private const float LANE_DISTANCE = 5.0f;

    // Movement
    private CharacterController controller;
    private float jumpForce = 4.0f;
    private float gravity = 12.0f;
    private float velocityChange;
    private float speed = 7.0f;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = rigth

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Gather wich Lane it should be
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLane(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveLane(true);
        }

        //Calculate where it should be, in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }

        //Calculationg move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;

        //Moving the Car
        controller.Move(moveVector * Time.deltaTime);
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight)? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);

        /* VERSION 0.1
        //Left
        if (!goingRight)
        {
            desiredLane--;
            if(desiredLane < 0)
            {
                desiredLane = 0;
            }
        }
        //Right
        else
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2; 
            }
        }
        */
    }
}
