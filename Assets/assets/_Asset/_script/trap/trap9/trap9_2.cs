using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap9_2 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    [SerializeField] private float moveSpeed = 2f;     // tốc độ di chuyển
    [SerializeField] private float rotationSpeed = 100f; // tốc độ quay (độ/giây)

    private Vector3 target;  // điểm đích hiện tại

    void Start()
    {
        // Bắt đầu di chuyển về phía điểm B
        target = pointB.position;
    }

    void Update()
    {
        // Di chuyển về phía mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // Nếu đã đến gần điểm đích thì đổi hướng (A ↔ B)
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }

        // Quay liên tục quanh trục Z
        transform.Rotate(0f,0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
