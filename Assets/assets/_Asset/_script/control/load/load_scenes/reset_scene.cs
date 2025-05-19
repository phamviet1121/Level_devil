using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset_scene : MonoBehaviour
{
   public string sceneName;
    public GameObject player;

    public void Reset()
    {
        if (player != null)
        {
            player.transform.SetParent(null);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) { Reset(); }
    }
}
