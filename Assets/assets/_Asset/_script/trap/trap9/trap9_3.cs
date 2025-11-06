using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap9_3 : MonoBehaviour
{
   
    public Transform pointA;
    public Transform pointB;

    [SerializeField] private float moveSpeed = 2f;      // tốc độ di chuyển
    [SerializeField] private float rotationSpeed = 100f; // tốc độ quay (độ/giây)

    private Vector3 target; // điểm đích hiện tại

    void Start()
    {
        // Bắt đầu di chuyển từ A → B
        transform.position = pointA.position;
        target = pointB.position;
    }

    void Update()
    {
        // Di chuyển dần từ A → B
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // Khi đến B, dịch chuyển (teleport) về A để đi lại
        if (Vector3.Distance(transform.position, pointB.position) < 0.05f)
        {
            transform.position = pointA.position; // quay lại A
        }

        // Quay liên tục quanh trục Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
