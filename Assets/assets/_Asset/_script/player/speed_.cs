using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_ : MonoBehaviour
{
    public float speed;
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    public Animator anim;
    private Transform child;
    public bool jump;

    void Start()
    {
        rb_strat();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal"); // -1 đến 1
        Vector2 velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        rb.velocity = velocity;


        // Xoay player theo hướng di chuyển
        if (Horizontal > 0)
        {
            child.transform.localScale = new Vector3(1, 1, 1); // Hướng phải
        }
        else if (Horizontal < 0)
        {
            child.transform.localScale = new Vector3(-1, 1, 1); // Hướng trái (lật scale X)
        }

        // Gửi thông tin sang Animator
        anim.SetFloat("mover", Mathf.Abs(Horizontal));

        if ((Input.GetKeyDown(KeyCode.Space)&& jump ==true)|| (Input.GetKeyDown(KeyCode.W)&& jump==true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //anim.SetBool("isJumping", true);
            anim.SetTrigger("onJump");
        }
    }

    public void OnJump()
    {
        jump=true;
    }
    public void OffJump()
    {
        jump=false;
    }
    private void rb_strat()
    {
        rb = null;


        //if (transform.childCount > 2) // đảm bảo có ít nhất 3 con
        //{
        //    Transform child = transform.GetChild(2); // index = 2 là con thứ 3
        //    rb = child.GetComponent<Rigidbody>();
        //}
        child = transform.GetChild(0);
        rb = child.GetComponent<Rigidbody2D>();
        anim = child.GetComponent<Animator>();

    }    





}
