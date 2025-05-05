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
    void Start()
    {
        originalPositionTop = backGroud_next_scenes_top.transform.position;
        originalPositionBoot = backGroud_next_scenes_boot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open()
    {
        backGroud_next_scenes_top.transform.position = location_top.transform.position;
        backGroud_next_scenes_boot.transform.position = location_boot.transform.position;
    }

    // di chuyen 1 vat tu vi tri đên 1 vi tri 
    // Obj : vật cần di chuyển
    // from :điểm bắt đầu
    // to: ddiemrr kết thúc 
    // duration: thời gian
    IEnumerator MoveFromTo(GameObject Obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
           // targetObject.position = Vector3.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo vị trí chính xác cuối cùng
      //  targetObject.position = to;
    }

}
