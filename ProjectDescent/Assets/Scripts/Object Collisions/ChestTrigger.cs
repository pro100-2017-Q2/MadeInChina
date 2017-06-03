using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestTrigger : MonoBehaviour {
    
    public Items[] items;

    public Items inChestItem;
    bool isPickedUp = false;

    void Start()
    {
        inChestItem = items[Random.Range(0, items.Length)];
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponentInParent<Player>() == null || isPickedUp == true)
        {
            return;
        }
        //Debug.Log("Pick up " + inChestItem.Name);
        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //    Debug.Log("Picked up: " + inChestItem.Name);
        //    inChestItem.UpdateStats();
        //    isPickedUp = true;
        //}
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
    }

}
