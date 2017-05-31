using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    public int enemiesKilled = 0;

    void Start()
    {
        tile = LevelController.level.WorldToTile(transform.position);
    }

    void Update()
    {
        tile = LevelController.level.WorldToTile(transform.position);
    }
}
