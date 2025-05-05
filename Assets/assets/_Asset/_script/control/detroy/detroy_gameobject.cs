using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class detroy_gameobject : MonoBehaviour
{

   // public UnityEvent<Collider2D> eventDetroy;

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(collision.gameObject);
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
       detroy_collisiongameObj(collision);
       // eventDetroy.Invoke(collision);
    }
    public void detroy_gameObj(Collider2D collision)
    {
        Destroy(gameObject);
    }
    public void detroy_collisiongameObj(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
