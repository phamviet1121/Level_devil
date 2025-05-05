using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class onclick_map : MonoBehaviour
{
    public float time;
    public string[] nameScenes;
    public int intScene;
    public UnityEvent EventNextScene;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  onclick_maps()
    {
        EventNextScene.Invoke();
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
