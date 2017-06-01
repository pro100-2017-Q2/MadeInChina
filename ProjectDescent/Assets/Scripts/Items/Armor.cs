using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript  {


    float Speed = -0.75f;
    int Armor = 1;

    void UpdateStats()
    {
        LevelController.player.Armour += Armor;
        LevelController.player.MoveSpeed += Speed;
    }
	
}
