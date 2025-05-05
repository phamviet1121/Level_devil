using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class next_scenes : MonoBehaviour
{
    public Animator animator; // Gán animator (hoặc tự tìm)
    public float animationTime = 2f; // Thời gian animation (nếu bạn biết trước)
    public string nextSceneName; // Tên scene cần load
    public UnityEvent event_nextScene;

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.SetActive(false);
            event_nextScene.Invoke();
           
        }
    }

    public void OnAnim_win()
    {
        animator.SetTrigger("win");
        StartCoroutine(NextSceneAfterAnim());

    }    

    private IEnumerator NextSceneAfterAnim()
    {
        yield return new WaitForSeconds(animationTime); // đợi anim chạy xong
        SceneManager.LoadScene(nextSceneName); // load scene mới
    }
}
