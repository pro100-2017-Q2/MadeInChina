using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int AgroRange;
    public Enemy enemy;

	void Start () {
        enemy = this.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerInRange())
        {
            PathToPlayer();
        }
        else
        {
            PathToRandomTile();
        }
	}

    bool PlayerInRange()
    {
        Tile playerTile = LevelController.player.tile;
        Debug.Log(playerTile.X + " " + playerTile.Y);
        if ((playerTile.X >= enemy.tile.X && playerTile.X < enemy.tile.X + AgroRange) || (playerTile.Y >= enemy.tile.Y && playerTile.Y < enemy.tile.Y + AgroRange))
        {
            return true;
        }
        return false;
    }

    void PathToRandomTile()
    {
        Debug.Log("No Enemy");
    }

    void PathToPlayer()
    {
        Debug.Log("Enemy");
    }
}
