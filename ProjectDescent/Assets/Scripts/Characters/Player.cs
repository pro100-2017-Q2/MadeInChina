using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int health = 3;
    private int armour = 3;
    private int movementSpeed = 1;
    private int attackDamage = 1;

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
    public int MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public int AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }



    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
