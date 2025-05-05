using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class isGrounded : MonoBehaviour
{
    public UnityEvent OnGround;
    public UnityEvent OffGround;
   
    private int groundCount = 0; // Đếm số ground đang chạm

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundCount++;
            if (groundCount == 1) // Vừa mới chạm ground đầu tiên
            {
                OnGround.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundCount--;
            if (groundCount <= 0) // Không còn chạm ground nào nữa
            {
                groundCount = 0; // Đảm bảo không xuống âm
                OffGround.Invoke();
            }
        }
    }
}
