using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steroids {

    int Strength = 1;

    void UpdateStats()
    {
        LevelController.player.AttackDamage += Strength;
    }
	
}
