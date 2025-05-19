using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class convert_collider : MonoBehaviour
{

    public Collider2D collider_obj;
    public float timedelay;

    private void Start()
    {
        collider_obj.enabled = false;
    }
    public void on_collider()
    {
        StartCoroutine(collider_obj_delay());
        
    }
    IEnumerator collider_obj_delay()
    {
        yield return new WaitForSeconds(timedelay) ;
        collider_obj.enabled = true;
    }    

}
