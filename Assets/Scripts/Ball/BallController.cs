using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    UýManager uiManager;

    public float moveSpeed = 5f;
    public Rigidbody2D rb { get; set; }

   

    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Debug.Log(rb.linearVelocity);
        uiManager = FindFirstObjectByType<UýManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            uiManager.score += 10;
            moveSpeed += 1;
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 ballPoint = collision.GetContact(0).point;
            Vector2 paddleCenter = collision.collider.bounds.center;

            float offset = ballPoint.x - paddleCenter.x;
            float bounceforce = moveSpeed + 4f;

            rb.linearVelocity = new Vector2(offset * bounceforce, rb.linearVelocity.y);
            
        }
    }
}
