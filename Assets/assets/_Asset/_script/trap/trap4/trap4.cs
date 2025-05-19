using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class trap4 : MonoBehaviour
{
    public GameObject trap;
    public GameObject[] location;
    private Rigidbody2D rb;
    private Vector2 startPosition;
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    public UnityEvent event_control_Trap4;

    public bool Collider2D_1;
    public bool Collider2D_2;
    public bool[] colliderFlags;
    public int pointCount1 = 1; // Số điểm đi qua khi Collider2D_1 = true

   // public int arr;

    private Coroutine currentCoroutine;

    void Start()
    {
        //colliderFlags = new bool[arr];
        //for (int i = 0; i < colliderFlags.Length; i++)
        //{
        //    colliderFlags[i] = false; // Tùy chọn vì mặc định đã là false
        //}
        Collider2D_1 = false;
        Collider2D_2 = false;
        if (trap != null)
        {
            rb = trap.GetComponent<Rigidbody2D>();
            startPosition = trap.transform.position;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Update()
    {
        if (Collider2D_2)
        {
            Collider2D_2 = false;
            if (currentCoroutine != null) StopCoroutine(currentCoroutine);
            int startIndex = Mathf.Clamp(pointCount1, 0, location.Length - 1); // điểm bắt đầu từ sau pointCount1
            currentCoroutine = StartCoroutine(MoveTrapFromTo(startIndex, location.Length - 1, moveSpeed*2));
        }
        else if (Collider2D_1)
        {
            Collider2D_1 = false;
            if (currentCoroutine != null) StopCoroutine(currentCoroutine);
            int targetCount = Mathf.Clamp(pointCount1, 1, location.Length);
            currentCoroutine = StartCoroutine(MoveTrapFromTo(0, targetCount - 1, moveSpeed));
        }
    }
    public void on_collider(int a)
    {
        if (a == 1)
        {
            Collider2D_1 = true;
        }
        else if (a == 2)
        {
            Collider2D_2 = true;
        }

    }

    IEnumerator MoveTrapFromTo(int startIdx, int endIdx ,float moveSpeedFlx)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        for (int i = startIdx; i <= endIdx; i++)
        {
            Vector2 targetPos = location[i].transform.position;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            while (Vector2.Distance(rb.position, targetPos) > 0.01f)
            {
                Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, moveSpeedFlx * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
                yield return new WaitForFixedUpdate();
            }

            rb.position = targetPos;
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (i < endIdx)
                yield return new WaitForSeconds(waitTime);
        }

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        currentCoroutine = null;
    }
}
