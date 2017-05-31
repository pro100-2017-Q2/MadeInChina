using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject playerPrefab;
    System.Random rand = new System.Random();

    public static LevelGeneration level;
    public static Player player;

    void Awake()
    {
        level = FindObjectOfType<LevelGeneration>();
    }

	void Start () {

        Debug.Log(level.mainRoom);
        Vector3 playerStart = level.TileToWorld(level.mainRoom.tiles[rand.Next(level.mainRoom.tiles.Count)]);
        GameObject playerObject = Instantiate(playerPrefab, playerStart, Quaternion.identity);

        FindObjectOfType<CameraController>().player = playerObject;
        player = playerObject.GetComponent<Player>();
    }
	
	void Update () {

		
	}
}
