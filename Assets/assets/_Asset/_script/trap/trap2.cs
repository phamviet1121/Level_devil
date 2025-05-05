using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trap2 : MonoBehaviour
{
    public GameObject trap;
    public GameObject location;
    private Rigidbody2D rb;
    public float falling_speed;
    public bool ontrap = true;
    public float stopDistance = 0.05f;

    private Vector2 startPosition;

    private bool goingToTarget = false;
    private bool returning = false;

    private bool three_way = false;
    private bool two_way = false;
    private bool one_way = false;


    public UnityEvent event_control_Trap2;


    void Start()
    {
        rb = trap.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll; // Đóng băng mọi thứ
        rb.isKinematic = true;
        startPosition = trap.transform.position;
    }
    void Update()
    {
        if (two_way == true)
        {
            two_way_movement();
        }
        if (one_way == true)
        {
            one_way_movement();
        }
        if (three_way == true)
        {
            three_way_movement();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null && ontrap == true)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                ontrap = false;
                goingToTarget = true;

                event_control_Trap2.Invoke();

                Vector2 direction = (location.transform.position - trap.transform.position).normalized;
                rb.velocity = direction * falling_speed;
            }

        }
    }

    public void two_way_movement()
    {
        if (goingToTarget && Vector2.Distance(trap.transform.position, location.transform.position) < stopDistance)
        {
            rb.velocity = Vector2.zero;

            // Bắt đầu quay lại
            goingToTarget = false;
            returning = true;

            Vector2 directionBack = (startPosition - (Vector2)trap.transform.position).normalized;
            rb.velocity = directionBack * (falling_speed*2);
        }

        else if (returning && Vector2.Distance(trap.transform.position, startPosition) < stopDistance)
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại
            returning = false;
        }
    }
    public void three_way_movement()
    {
        if (goingToTarget && Vector2.Distance(trap.transform.position, location.transform.position) < stopDistance)
        {
            rb.velocity = Vector2.zero;

            // Bắt đầu quay lại
            goingToTarget = false;
            returning = true;

            Vector2 directionBack = (startPosition - (Vector2)trap.transform.position).normalized;
            rb.velocity = directionBack * (falling_speed * 2);
        }

      
    }
    public void one_way_movement()
    {
        if (!ontrap && Vector2.Distance(trap.transform.position, location.transform.position) < stopDistance)
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại khi đã đến nơi
        }
    }
    public void two_way_movement_bool()
    {
        two_way = true;
        one_way = false;
    }
    public void one_way_movement_bool()
    {
        one_way = true;
        two_way = false;
    }
    public void three_way_movement_bool()
    {
        three_way = true;
      
    }
}
