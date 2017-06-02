using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour {
    public RectTransform heart1;
    public RectTransform heart2;
    public RectTransform heart3;
    // Use this for initialization
    void Start () {
        LevelController.player.Health = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(LevelController.player.Health < 3)
        {
            heart3.gameObject.SetActive(false);
        } else if(LevelController.player.Health < 2)
        {
            heart2.gameObject.SetActive(false);
        }
        else if(LevelController.player.Health < 1)
        {
            heart1.gameObject.SetActive(false);
        }

	}
}
