using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class on_collder2d_1 : MonoBehaviour
{
    public int on_collder_int;
    public bool on_collder;
    public UnityEvent<int> on_collder_changed;

    private void Start()
    {
        on_collder=true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           if(on_collder==true)
            {
                on_collder = false;
                on_collder_changed.Invoke(on_collder_int);
            }

        }
    }

}
