using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Items
{


    float Speed = -0.75f;
    int Armour = 1;

    void Start()
    {
        Name = "Armour";
    }

    public override void UpdateStats()
    {
        LevelController.player.Armour += Armour;
        LevelController.player.MoveSpeed += Speed;
    }
}
