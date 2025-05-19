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

    public bool three_way = false;
    public bool two_way = false;
    public bool one_way = false;
    public bool one_way_ObjFalse = false;

    public UnityEvent event_control_Trap2;


    void Start()
    {
        rb = trap.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
       // rb.constraints = RigidbodyConstraints2D.FreezeAll; // Đóng băng mọi thứ
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.isKinematic = true;
        startPosition = trap.transform.position;
    }
    void FixedUpdate()
    {
        if (two_way == true)
        {
            two_way_movement();
        }
        if (one_way == true)
        {
           // Debug.Log("cos hoat ddong cai nay one_way");
            one_way_movement();
        }
        if (three_way == true)
        {
            three_way_movement();
        }
        if (one_way_ObjFalse == true)
        {
           // Debug.Log("cos hoat ddong cai nay one_way_ObjFalse");
            one_way_movement_objFalse();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null && ontrap == true)
            {
               // rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
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
            rb.velocity = directionBack * (falling_speed * 2);
        }

        else if (returning && Vector2.Distance(trap.transform.position, startPosition) < stopDistance)
        {
            rb.velocity = Vector2.zero;
           // rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại
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
           // Debug.Log("cos chay ham one_way_movement()");
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại khi đã đến nơi
            rb.velocity = Vector2.zero;
            trap.transform.position = location.transform.position;
        }
    }

    //public void one_way_movement()
    //{
    //    Vector2 toTarget = ((Vector2)location.transform.position - startPosition).normalized;

    //    Vector2 currentDirection = ((Vector2)trap.transform.position - startPosition).normalized;
    //    Debug.Log("1");

    //    float dot = Vector2.Dot(toTarget, currentDirection);

    //    if (!ontrap && dot < 0.99f) // hoặc dùng dot <= 0 nếu bạn muốn chính xác đã vượt qua
    //    {
    //        Debug.Log("cos chay ham one_way_movement()");
    //        rb.velocity = Vector2.zero;
    //        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    //        trap.transform.position = location.transform.position;
    //    }
    //}


    public void one_way_movement_objFalse()
    {
        if (!ontrap && Vector2.Distance(trap.transform.position, location.transform.position) < stopDistance)
        {
           // Debug.Log("cos chay ham one_way_movement_objFalse");
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại khi đã đến nơi
            trap.SetActive(false);
        }
    }
    //public void one_way_movement_objFalse()
    //{
    //    Debug.Log("2");
    //    Vector2 toTarget = ((Vector2)location.transform.position - startPosition).normalized;

    //    Vector2 currentDirection = ((Vector2)trap.transform.position - startPosition).normalized;


    //    float dot = Vector2.Dot(toTarget, currentDirection);

    //    if (!ontrap && dot < 0.99f) // hoặc dùng dot <= 0 nếu bạn muốn chính xác đã vượt qua
    //    {
    //        Debug.Log("cos chay ham one_way_movement_objFalse");
    //        rb.velocity = Vector2.zero;
    //        rb.constraints = RigidbodyConstraints2D.FreezeAll; // Khóa lại khi đã đến nơi
    //        trap.SetActive(false);
    //    }
    //}
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
    public void one_way_ObjFalse_movement_bool()
    {
        one_way_ObjFalse = true;

    }
}
