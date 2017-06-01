using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots {

    float Speed = 0.5f;

    public void UpdateStats()
    {
        LevelController.player.MoveSpeed += Speed;
    }
    
}
