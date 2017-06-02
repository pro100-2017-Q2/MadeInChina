using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour{
    
    public int Health = 5;
    public int AttackDamage = 1;
    public float MoveSpeed = 1;
    public int Armour = 0;

    public Tile tile;

    public int DealDamage()
    {
        return AttackDamage;
    }

    public void TakeDamage(int takenDamage)
    {
        if(Armour > 0)
        {
            Armour -= takenDamage;
        }
        else
        {
            Health -= takenDamage;
        }
    }


}
