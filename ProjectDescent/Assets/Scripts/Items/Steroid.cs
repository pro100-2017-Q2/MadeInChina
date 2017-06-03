using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steroid : Items
{

    int Strength = 1;

    void Start()
    {
        Name = "Steroids";
    }

    public override void UpdateStats()
    {
        LevelController.player.AttackDamage += Strength;
    }
	
}
