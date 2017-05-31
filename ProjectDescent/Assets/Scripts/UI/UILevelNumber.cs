using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelNumber : MonoBehaviour {
    public Text levelText;
    // Use this for initialization
    void Start()
    {
        levelText = GetComponent<Text>();
        DisplayLevelCount();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLevelCount();
    }

    public void DisplayLevelCount()
    {
        levelText.text = "Level: " + LevelController.level.levelCount.ToString();
    }
    
}
