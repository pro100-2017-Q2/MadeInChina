using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour {

    private int health = 3;
    private int MaxHealth;
    private int armour = 3;

    private int movementSpeed = 1;
    private int attackDamage = 1;
    //private GameObject HealthGO;
    

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

    public void TakeDamage()
    {
        //Take/ receive damage
        Debug.Log(Health);
        Health -= 1;
        if (Health <= 0)
        {
            kill();
        }
        //HealthBar.fillamount = (float)health/ MaxHealth;
    }
    public void kill()
    {
        Destroy(gameObject);
    }

    void start()
    {
        //HealthBar = HealthBarGo.GetComponent<Image>();
        Health = MaxHealth;
    }
}
