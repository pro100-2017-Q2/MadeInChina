using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {

    public GameObject[] spawnPrefabs;

    public List<ChestTrigger> spawnedObjects = new List<ChestTrigger>();

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
        spawnPos.y = -3;
        GameObject chest_go = Instantiate(spawnPrefabs[rand.Next(spawnPrefabs.Length)], spawnPos, Quaternion.identity);

        spawnedObjects.Add(chest_go.GetComponentInChildren<ChestTrigger>());
    }

    public void DeleteAllEnemies()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
    }
}
