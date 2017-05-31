using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private float health = 5.0F;
    private int moveSpeed = 1;
    private float armour = 0.0F;
    private int[] hand = new int[2];

    public int enemiesKilled = 0;

    void Start()
    {
        while (LevelController.level.Rooms == null)
        {
            tile = LevelController.level.WorldToTile(this.transform.position);
            foreach (Room r in LevelController.level.Rooms)
            {
                if (r.tiles.Contains(tile))
                {
                    room = r;
                    return;
                }
            }

        }
    }

    //public Player()
    //{
    //    Health = this.health;
    //    MoveSpeed = this.moveSpeed;
    //    Armour = this.armour;

    //}
}
