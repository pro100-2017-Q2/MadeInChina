using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Enemy enemy;
    Vector3 velocity;
    Rigidbody rig;

	void Start () {
        enemy = this.GetComponent<Enemy>();
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        PathToPlayer();
	}

    public static bool PlayerInRange(int range, Enemy enemy)
    {
        Tile playerTile = LevelController.player.tile;
        if ((playerTile.X >= enemy.tile.X && playerTile.X < enemy.tile.X + range) || (playerTile.Y >= enemy.tile.Y && playerTile.Y < enemy.tile.Y + range))
        {
            return true;
        }
        return false;
    }

    void PathToPlayer()
    {
        velocity = (LevelController.player.transform.position - transform.position).normalized * enemy.MoveSpeed;
        rig.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}
