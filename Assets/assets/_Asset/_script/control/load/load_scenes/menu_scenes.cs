using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_scenes : MonoBehaviour
{
    public UnityEvent event_nextMenu;
    public string nameScene;
    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.interactable = true;
    }
    public void onclickMenu()
    {
        event_nextMenu.Invoke();
        if (btn != null)
        {
            btn.interactable = false;                      
        }
    } 
    public void nextMenuScenes()
    {
        StartCoroutine(NextScene());
    }    
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f); // đợi anim chạy xong
        SceneManager.LoadScene(nameScene); // load scene mới
    }
}
