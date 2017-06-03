using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public RectTransform gameoverScreen;
	// Update is called once per frame
	void Update () {
		
	}
    public void DisplayGameOver()
    {
        gameoverScreen.gameObject.SetActive(true);
    }
}
