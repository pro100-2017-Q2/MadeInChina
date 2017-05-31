using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemiesKilled : MonoBehaviour {
    public Text enemiesKilledText;
    // Use this for initialization
    void Start () {
        enemiesKilledText = GetComponent<Text>();
        DisplayEnemiesKilled();
    }
	
	// Update is called once per frame
	void Update () {
        DisplayEnemiesKilled();
    }
    public void DisplayEnemiesKilled()
    {
        if (LevelController.player != null)
        {
            enemiesKilledText.text = "Enemies \nKilled: " + LevelController.player.enemiesKilled;
        }
        //Debug.Log(LevelController.player.enemiesKilled);
    }
}
