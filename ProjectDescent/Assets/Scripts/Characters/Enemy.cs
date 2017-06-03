using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats {

    public int attackRange = 2;
    Collider col;

	void Start () {
        tile = LevelController.level.WorldToTile(transform.position);
        col = GetComponent<Collider>();
	}
	
	void Update () {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        tile = LevelController.level.WorldToTile(transform.position);

        if (EnemyMovement.PlayerInRange(attackRange, this))
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        if (attackRange > 2)
        {
            //Range Attack
        }
        else
        {

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.GetComponentInParent<Player>() != null)
        {
            LevelController.player.TakeDamage(AttackDamage);
        }
    }

}
