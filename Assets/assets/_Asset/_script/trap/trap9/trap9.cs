using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap9 : MonoBehaviour
{
    public GameObject gameobjgroud9;
    public float rotationSpeed = 1f; // đơn vị độ/giây
    void Update()
    {
        gameobjgroud9.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
