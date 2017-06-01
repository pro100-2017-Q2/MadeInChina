using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChestTrigger : MonoBehaviour {
    
    Random rand = new Random();

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponentInParent<Player>() == null)
        {
            return;
        }
        
        int randomNumber = Random.Range(1, 101);

        //if (randomNumber <= 5)
        //{
        //    //Player Picks up Bazooka
        //    //Player.Gun = true;
        //}
        if (randomNumber <= 49)
        {
            //Player gains armor
            //Stats.Armour += 1.0f;
        }
        if (randomNumber >= 50 && randomNumber <= 75)
        {
            //Player gains strength
            //Stats.Strength += 1;
        }
        if (randomNumber >= 76)
        {
            //player gains speed
            //Stats.MoveSpeed += 1;
        }
       
    }

}
