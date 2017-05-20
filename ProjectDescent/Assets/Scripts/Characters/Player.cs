using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private float health = 5.0F;
    private int moveSpeed = 1;
    private float armour = 0.0F;
    private int[] hand = new int[2];


    public Player()
    {
        Health = this.health;
        MoveSpeed = this.moveSpeed;
        Armour = this.armour;

    }
}
