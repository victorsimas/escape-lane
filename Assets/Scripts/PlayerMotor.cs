using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //Constants
    private const float LANE_DISTANCE = 5.0f;
    private const float TURN_SPEED = 0.1f;

    //Validation for start
    private bool isRunning = false;

    // Movement
    private CharacterController controller;
    private float jumpForce = 14.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = rigth

    //Speed Modifier
    private float originalSpeed = 20.0f;
    private float speed;
    private float speedIncreaseLastTick;
    private float speedIncreaseTime = 2.5f;
    private float speedIncreaseAmount = 0.1f;

    private void Start()
    {
        speed = originalSpeed;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!isRunning)
        {
            return;
        }

        //Speed change
        if (Time.time - speedIncreaseLastTick > speedIncreaseTime)
        {
            speedIncreaseLastTick = Time.time;
            speed += speedIncreaseAmount;
            GameManager.Instance.UpdateModifier(speed -  originalSpeed);
        }

        // Gather wich Lane it should be
        if (MobileScript.Instance.SwipeLeft)
        {
            MoveLane(false);
        }
        if (MobileScript.Instance.SwipeRight)
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

        bool isGrounded = IsGrounded();
        //Calculating Y
        if (isGrounded)
        {
            verticalVelocity = -0.1f;

            //Jump
            //if (MobileScript.Instance.SwipeUp)
            //{
            //    verticalVelocity = jumpForce;
            //}
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            //Fast Falling mechaninc
            //if (MobileScript.Instance.SwipeDown)
            //{
            //    verticalVelocity -= jumpForce;
            //}
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        //Moving the Car
        controller.Move(moveVector * Time.deltaTime);

        //Rotate the Car
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }
    }

    private void MoveLane(bool goingRight)
    {
        //Checks goingRight result and defines limit
        desiredLane += (goingRight)? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        //Generate a ground Ray and bases it origin by the controller bounds 
        Ray groundRay = new Ray(
            new Vector3(
                controller.bounds.center.x,
                (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
                controller.bounds.center.z),
            Vector3.down);

        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1f);
        //Returns if groundRay touches anything
        return Physics.Raycast(groundRay, 0.2f + 0.1f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Obstacle":
                Crash();
                break;
        }
    }

    private void Crash()
    {
        isRunning = false;
        GameManager.Instance.isDead = true;
    }

    public void StartRunning()
    {
        isRunning = true;
    }
}
