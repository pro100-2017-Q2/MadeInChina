using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestTrigger : MonoBehaviour {
    
    public Items[] items;
    public RectTransform chestMenu;
    public Items inChestItem;
    bool isPickedUp = false;

    public void ExitChest()
    {
        if (chestMenu.gameObject.activeInHierarchy == true)
        {
                chestMenu.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        inChestItem = items[Random.Range(0, items.Length)];
        chestMenu = FindObjectOfType<ChestFunctionality>().GetComponentInParent<RectTransform>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponentInParent<Player>() == null || isPickedUp == true)
        {
            return;
        }

        chestMenu.gameObject.SetActive(true);

        inChestItem.ChestMenu.DisplayChestItem(inChestItem.Name);
    }

    void OnTriggerStay(Collider col)
    {
        if (isPickedUp == true)
        {
            return;
        }
        Debug.Log("Pick up " + inChestItem.Name);
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("Picked up: " + inChestItem.Name);
            inChestItem.UpdateStats();
            isPickedUp = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitChest();
        }
    }

    void OnTriggerLeave(Collider col)
    {
        ExitChest();
    }

}
