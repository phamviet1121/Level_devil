using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detroy : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject);

        }

    }
}
