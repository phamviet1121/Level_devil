using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap5 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float waitTime = 2f;


    private Vector3 target;
    private bool isWaiting = false;

    private Vector3 originalScale;

    private GameObject a;

    private void Start()
    {
        target = pointB.position;
        StartCoroutine(MovePlatform());
        a = GetComponent<GameObject>();
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }

            // Dừng lại
            yield return new WaitForSeconds(waitTime);

            // Đổi hướng
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    // Gắn player vào platform để di chuyển cùng
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (collision.transform != null)
            //{
                originalScale = collision.transform.localScale;
                collision.transform.SetParent(this.transform);
                collision.transform.localScale = originalScale;
           // }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.isActiveAndEnabled)
        {
            StartCoroutine(DetachNextFrame(collision.transform));
        }
    }

    private IEnumerator DetachNextFrame(Transform objTransform)
    {
        yield return null;  // đợi 1 frame
        if (objTransform != null)
        {
            try
            {
                objTransform.SetParent(null);
            }
            catch (System.Exception)
            {
                // Bỏ qua lỗi, không làm gì
            }
        }
    }

}
