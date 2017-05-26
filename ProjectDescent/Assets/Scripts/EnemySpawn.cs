using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {


    //add multiple to one game object
    public GameObject[] enemyPrefabs;

    public List<Enemy> enemies = new List<Enemy>();

    public int threshold = 15;

    public LevelGeneration level;

    System.Random rand = new System.Random();


    ////boundries for how long we want to spawn objects and
    ////as well as boundries
    //public Vector3 spawnValues;


    ////
    //public float spawnWait;

    ////time increments when we want to spawn are object to be in
    //public float spawnMostWait;

    //public float spawnLeastWait;

    ////
    //public int startWait;

    //public bool stop;

    //int randEnemy;


    // Use this for initialization
    void Start()
    {
        //level = FindObjectOfType<LevelGeneration>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (enemies.Count == threshold)
        {
            return;
        }

        Room spawnRoom = level.Rooms[rand.Next(level.Rooms.Count)];
        Tile spawnTile = spawnRoom.tiles[rand.Next(spawnRoom.tiles.Count)];

        GameObject enemy_go = Instantiate(enemyPrefabs[rand.Next(enemyPrefabs.Length)], level.TileToWorld(spawnTile), Quaternion.identity);

        enemies.Add(enemy_go.GetComponent<Enemy>());
    }

    public void DeleteAllEnemies()
    {
        DestroyObject(enemies[0]);
    }


}
