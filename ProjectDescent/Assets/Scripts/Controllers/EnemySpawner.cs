using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    public GameObject[] spawnPrefabs;

    public List<Enemy> spawnedObjects = new List<Enemy>();

    public int threshold = 15;

    System.Random rand = new System.Random();

    void Start()
    {

    }

    void LateUpdate()
    {
        if (spawnedObjects.Count == threshold)
        {
            return;
        }

        Tile spawnTile = LevelController.level.allRoomTiles[rand.Next(LevelController.level.allRoomTiles.Count)];
        Vector3 spawnPos = LevelController.level.TileToWorld(spawnTile);
        GameObject enemy_go = Instantiate(spawnPrefabs[rand.Next(spawnPrefabs.Length)], spawnPos, Quaternion.identity);

        spawnedObjects.Add(enemy_go.GetComponent<Enemy>());
    }

    public void DeleteAllEnemies()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
    }


}
