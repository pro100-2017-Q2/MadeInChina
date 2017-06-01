using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour{
    
    public float health = 5F;
    public float attackDamage = 0.5F;
    public float moveSpeed = 1;
    public float armour = 1;
    public Weapon weapon;

    public Room room;
    public Tile tile;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
        }
    }
    public float AttackDamage
    {
        get { return attackDamage; }
        set
        {
            attackDamage = value;
        }
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            moveSpeed = value;
        }
    }
    public float Armour
    {
        get { return armour; }
        set
        {
            armour = value;
        }
    }

    public float DealDamage()
    {
        return AttackDamage;
    }
    public void TakeDamage(float takenDamage)
    {
        //Health = Health - takenDamage;
    }
    public void IncreaseArmour(float armour)
    {
        //Armour = Armour + armour;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
