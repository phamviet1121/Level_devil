using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trap3 : MonoBehaviour
{

    public GameObject trap;
    public GameObject[] location;
    private Rigidbody2D rb;
    private Vector2 startPosition;
    public bool ontrap = true;
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    public UnityEvent event_control_Trap3;
    void Start()
    {
        if (trap != null)
        {
          
            rb = trap.GetComponent<Rigidbody2D>();
            startPosition = trap.transform.position;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rb != null && ontrap == true)
            {
                if (rb != null && location.Length > 0)
                {
                    ontrap=false;
                    event_control_Trap3.Invoke();
                }
            }

        }
    }
    public void MoveTrap_L_n()
    {
        StartCoroutine(MoveTrapWithPhysics_L_n());
    }


    IEnumerator MoveTrapWithPhysics_L_n()
    {
      //  rb.constraints = RigidbodyConstraints2D.None;
        for (int i = 0; i < location.Length; i++)
        {
            Vector2 targetPos = location[i].transform.position;

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            while (Vector2.Distance(rb.position, targetPos) > 0.01f)
            { 
                Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
                yield return new WaitForFixedUpdate();
            }

            rb.position = targetPos;
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (i < location.Length - 1)
            {
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
