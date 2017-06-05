using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenScript : MonoBehaviour {
    public RectTransform gameoverScreen;
    // Update is called once per frame
    void Update()
    {
        DisplayGameOver();
    }
    public void DisplayGameOver()
    {
        gameoverScreen.gameObject.SetActive(true);
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
