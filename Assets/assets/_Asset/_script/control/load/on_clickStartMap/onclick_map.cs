using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onclick_map : MonoBehaviour
{
    public float time;
    public string[] nameScenes;
    public int intScene;
    public UnityEvent EventNextScene;
    Button btn;

    void Start()
    {
         btn = GetComponent<Button>();
        //btn.interactable = true;
    }

    public void  onclick_maps()
    {
        EventNextScene.Invoke();
        if (btn != null)
        {
            btn.interactable = false;   
        }
    }
    public void on_click_backgroudNextScene()
    {
        StartCoroutine(NextScene());
    }
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(time); // đợi anim chạy xong
        SceneManager.LoadScene(nameScenes[intScene]); // load scene mới
    }

}
