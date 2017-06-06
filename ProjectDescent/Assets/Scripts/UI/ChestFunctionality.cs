using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestFunctionality : MonoBehaviour
{
    
    public Text chestItem;
    void Start()
    {
        chestItem = GetComponentInChildren<Text>();
        DisplayChestItem();
    }
    void Update()
    {
        DisplayChestItem();
    }
    public void DisplayChestItem()
    {
        chestItem.text = "hello";
    }
}
