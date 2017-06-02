using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorCount : MonoBehaviour {
    public Text armorCount;
	// Use this for initialization
	void Start () {
        armorCount = GetComponent<Text>();
        DisplayArmorCount();
	}
	
	// Update is called once per frame
	void Update () {
        DisplayArmorCount();
	}
    public void DisplayArmorCount()
    {
        armorCount.text = "Armor: " + LevelController.player.Armour.ToString();
    }
}
