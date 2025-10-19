using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_gameobject_loadScenes : MonoBehaviour
{
    public GameObject backGroud_next_scenes_top;
    public GameObject backGroud_next_scenes_boot;

    public GameObject location_top;
    public GameObject location_boot;


    private Vector3 originalPositionTop;
    private Vector3 originalPositionBoot;

    public float time;
    private Coroutine currentTopCoroutine;
    private Coroutine currentBootCoroutine;
    void Start()
    {
        
        originalPositionTop = backGroud_next_scenes_top.transform.position;
        originalPositionBoot = backGroud_next_scenes_boot.transform.position;
        gameObject.SetActive(false);
       if (GameState.hasPlayedOpenAnimation==false)
        {
            open();

        }    




    }

    // Update is called once per frame
    void Update()
    {

    }
    public void close()
    {
        gameObject.SetActive(true);
        StopAllCurrentAnimations();
        // Bắt đầu coroutine mới cho close
        currentTopCoroutine = StartCoroutine(MoveFromTo(backGroud_next_scenes_top, location_top.transform.position, originalPositionTop, time));
        currentBootCoroutine = StartCoroutine( MoveFromTo(backGroud_next_scenes_boot, location_boot.transform.position, originalPositionBoot, time));
        //StartCoroutine(MoveFromTo(backGroud_next_scenes_top, location_top.transform.position, originalPositionTop, time));
        //StartCoroutine(MoveFromTo(backGroud_next_scenes_boot, location_boot.transform.position, originalPositionBoot, time));
        GameState.hasPlayedOpenAnimation = false;
    }
    public void open()
    {
        gameObject.SetActive(true);

        // Dừng tất cả coroutine cũ nếu có
        StopAllCurrentAnimations();
        // Bắt đầu coroutine mới cho open
        currentTopCoroutine = StartCoroutine(MoveFromTo(backGroud_next_scenes_top, originalPositionTop, location_top.transform.position, time));
        currentBootCoroutine = StartCoroutine(MoveFromTo(backGroud_next_scenes_boot, originalPositionBoot, location_boot.transform.position, time));

        //StartCoroutine(MoveFromTo(backGroud_next_scenes_top, originalPositionTop, location_top.transform.position, time));
        //StartCoroutine(MoveFromTo(backGroud_next_scenes_boot, originalPositionBoot, location_boot.transform.position, time));
        GameState.hasPlayedOpenAnimation = true;
    }


    // di chuyen 1 vat tu vi tri đên 1 vi tri 
    // Obj : vật cần di chuyển
    // from :điểm bắt đầu
    // to: ddiemrr kết thúc 
    // duration: thời gian

    private void StopAllCurrentAnimations()
    {
        if (currentTopCoroutine != null)
        {
            StopCoroutine(currentTopCoroutine);
            currentTopCoroutine = null;
        }

        if (currentBootCoroutine != null)
        {
            StopCoroutine(currentBootCoroutine);
            currentBootCoroutine = null;
        }
    }

    IEnumerator MoveFromTo(GameObject Obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        Obj.transform.position = from; // Đặt Obj tại vị trí bắt đầu

        while (elapsed < duration)
        {
            // Di chuyển mượt mà từ 'from' đến 'to'
            Obj.transform.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo vật được đặt chính xác tại vị trí 'to'
        Obj.transform.position = to;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        //if (!GameState.hasPlayedOpenAnimation)
        //{
        //    yield return new WaitForSeconds(2f);
        //    gameObject.SetActive(false);
        //}
    }

}
