using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestFunctionality : MonoBehaviour
{
    
    public Text chestItem;
    public string name = "";

    void Start()
    {
        chestItem = GetComponentInChildren<Text>();
        DisplayChestItem(name);
    }
    void Update()
    {
        DisplayChestItem(name);
    }
    public void DisplayChestItem(string _name)
    {
        name = _name;
        chestItem.text = name;
    }
}
