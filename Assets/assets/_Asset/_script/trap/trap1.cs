using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    public GameObject trap;
    private Rigidbody2D rb;
    public float falling_speed;
    void Start()
    {
        rb = trap.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll; // Đóng băng mọi thứ
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.None; // Mở khóa
                rb.gravityScale = falling_speed;
            }

        }
    }
}
