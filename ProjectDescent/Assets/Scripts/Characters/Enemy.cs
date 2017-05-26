using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats {


	void Start () {
        while(LevelController.level.Rooms == null)
        {
            tile = LevelController.level.WorldToTile(this.transform.position);
            Debug.Log(tile.X + " " + tile.Y);
            foreach(Room r in LevelController.level.Rooms)
            {
                if (r.tiles.Contains(tile))
                {
                    room = r;
                    return;
                }
            }

        }
	}
	
	void Update () {
		
	}

}
