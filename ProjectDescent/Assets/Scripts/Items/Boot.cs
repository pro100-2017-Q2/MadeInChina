using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : Items
{

    float Speed = 0.5f;

    void Start()
    {
        Name = "Boots";
    }

    public override void UpdateStats()
    {
        LevelController.player.MoveSpeed += Speed;
    }
    
}
