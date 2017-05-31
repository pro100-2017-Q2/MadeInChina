using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Stats {


	void Start () {
        tile = LevelController.level.WorldToTile(transform.position);
	}
	
	void Update () {
        tile = LevelController.level.WorldToTile(transform.position);
    }

}
