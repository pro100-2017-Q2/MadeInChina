﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Stats : MonoBehaviour, INotifyPropertyChanged{

    public event PropertyChangedEventHandler PropertyChanged;
    private float health = 5F;
    private float attackDamage = 0.5F;
    private int moveSpeed = 1;
    private float armour;
    private Weapon weapon;

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
    public int MoveSpeed
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
        Health = Health - takenDamage;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
