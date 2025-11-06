using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap9_1 : MonoBehaviour
{
    public GameObject gameobjgroud9_1;
    [SerializeField] private float rotationSpeed = 60f; // tốc độ quay (độ/giây)
    [SerializeField] private float maxAngle = 30f;      // góc tối đa
    private int direction = 1;        // 1 = quay thuận, -1 = quay ngược

    void Update()
    {
        // Lấy góc hiện tại (0–360)
        float currentZ = gameobjgroud9_1.transform.localEulerAngles.z;

        // Chuyển về khoảng -180 → 180 để so sánh dễ
        if (currentZ > 180f)
            currentZ -= 360f;

        // Nếu đạt tới giới hạn thì đảo chiều
        if (currentZ >= maxAngle)
            direction = -1;
        else if (currentZ <= -maxAngle)
            direction = 1;

        // Quay theo hướng hiện tại
        gameobjgroud9_1.transform.Rotate(0f, 0f, rotationSpeed * direction * Time.deltaTime);
    }
}
