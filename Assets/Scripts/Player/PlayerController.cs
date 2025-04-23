using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 10f;
    Vector2 direction; 
    Rigidbody2D rb;

    BallController ballController;
    Rigidbody2D ballRb;
    bool gameStarted = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballController = FindAnyObjectByType<BallController>();
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = moveSpeed * direction;
    }

    public void SideMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void PushBall(InputAction.CallbackContext context)
    {
        ballRb = ballController.rb;
        Vector2 ballLaunch = new Vector2(direction.x, 1);

        if (!gameStarted && context.performed) {
            Debug.Log("space pressed");
            ballRb.linearVelocity = moveSpeed * ballLaunch;
            gameStarted = true;
        }
    }
}
