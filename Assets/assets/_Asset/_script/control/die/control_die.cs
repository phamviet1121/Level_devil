using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class control_die : MonoBehaviour
{
    public GameObject game_Over;

    public GameObject square;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("detroy"))
    //    {
    //        gameObject.SetActive(false);
    //        OnDie();
    //    }
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("detroy"))
        {
            gameObject.SetActive(false);
            OnDie();
        }
    }

    public void OnDie()
    {
        int quantity = Random.Range(5, 20);

        for (int i = 0; i < quantity; i++)
        {
            // Tạo instance tại vị trí của object đang gọi OnDie
            GameObject clone = Instantiate(square, transform.position, Quaternion.identity);

            // Xoay ngẫu nhiên
            float rotation = Random.Range(0f, 360f);
            clone.transform.rotation = Quaternion.Euler(0f, 0f, rotation);

            // Đổi kích thước ngẫu nhiên
            float size = Random.Range(0.1f, 0.3f);
            clone.transform.localScale = new Vector3(size, size, 1f);

            // Thêm lực đẩy ngẫu nhiên ra các hướng
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDir = Random.insideUnitCircle.normalized;
                float randomForce = Random.Range(1f, 4f); // tùy điều chỉnh
                rb.AddForce(randomDir * randomForce, ForceMode2D.Impulse);
            }

            // (Tuỳ chọn) Tự hủy sau vài giây cho gọn scene
            Destroy(clone, Random.Range(0.1f, 1f));
        }
    }
}
