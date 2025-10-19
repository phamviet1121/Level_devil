using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
   // public float rollSpeed = 5f;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public bool left_right = true;

   // public float rollSpeedFactor = 1f;
    private float ballRadius = 0.5f;
   // private float mass = 1f;

    private void Start()
    {
        if (rb != null)
        {
            CircleCollider2D col = GetComponent<CircleCollider2D>();
            ballRadius = col.radius * transform.localScale.x;
             ballRadius = col.radius * rb.transform.localScale.x;
        }
    }
    public void rolli_left()
    {
        left_right = false;
        Vector2 force = Vector2.left * moveSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void rolli_right()
    {
        left_right = true;
        Vector2 force = Vector2.right * moveSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void SetAngularVelocity(float forceX)
    {
        float expectedVelocityX = forceX / rb.mass;
        float angularVelocity = -expectedVelocityX / ballRadius;
        rb.angularVelocity = angularVelocity;
    }

    private void FixedUpdate()
    {   
        float vx = rb.velocity.x;
        rb.angularVelocity = -vx / ballRadius * Mathf.Rad2Deg;
    }

}
