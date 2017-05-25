using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject levelPrefab;
    public GameObject playerPrefab;
    System.Random rand = new System.Random();

    public static LevelGeneration level;

    public bool isStart = true;

	// Use this for initialization
	void Start () {
        Instantiate(levelPrefab);
        level = FindObjectOfType<LevelGeneration>();

	}
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            Tile playerStart = level.mainRoom.tiles[rand.Next(level.mainRoom.tiles.Count)];

            Instantiate(playerPrefab, new Vector3(playerStart.X, 0, playerStart.Y), Quaternion.identity);

            isStart = false;
        }
       
		
	}
}
