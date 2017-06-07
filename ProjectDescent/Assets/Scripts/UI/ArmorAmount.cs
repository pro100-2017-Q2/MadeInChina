using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorAmount : MonoBehaviour {
    public Text armorCount;
	// Use this for initialization
	void Start () {
        armorCount = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DisplayArmorCount()
    {
        armorCount.text = "Armor: ";
    }
}
