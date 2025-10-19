using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collider_trap7 : MonoBehaviour
{
    public bool on_collder = true;
    public UnityEvent event_collider_trap7;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (on_collder == true)
            {
                on_collder = false;
                event_collider_trap7.Invoke();
            }

        }
    }
}
