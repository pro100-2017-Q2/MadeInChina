using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {
    //public Transform menu;
    public RectTransform menu;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

	}
    public void Pause()
    {
        if(menu.gameObject.activeInHierarchy == false)
        {
            menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
