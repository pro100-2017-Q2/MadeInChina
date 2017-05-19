using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private int health;
    private int armour;
    private int attackdamage;
    private int movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public int Health
    {
        get { return health; }
        set { health = value; }
    }


    public int Armour
    {
        get { return armour; }
        set { armour = value; }
    }


    public int AttackDamage
    {
        get { return attackdamage; }
        set { attackdamage = value; }
    }

    public int MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }




}
