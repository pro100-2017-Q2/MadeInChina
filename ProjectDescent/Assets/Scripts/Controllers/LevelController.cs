using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public GameObject playerPrefab;
    System.Random rand = new System.Random();

    public static LevelGeneration level;
    public static Player player;

    public GameObject ladderPrefab;

    public Canvas canvas;
    public static bool playerDead = false;
    public GameObject DeathScreen;

    void Awake()
    {
        level = FindObjectOfType<LevelGeneration>();
        canvas = FindObjectOfType<Canvas>();
    }

	void Start () {

        Vector3 playerStart = level.TileToWorld(level.mainRoom.tiles[rand.Next(level.mainRoom.tiles.Count)]);
        GameObject playerObject = Instantiate(playerPrefab, playerStart, Quaternion.identity);

        Vector3 LadderPos = level.TileToWorld(level.mainRoom.tiles[rand.Next(level.mainRoom.tiles.Count)]);
        Instantiate(ladderPrefab, LadderPos, Quaternion.identity);

        player = playerObject.GetComponent<Player>();
    }
	
	void Update () {
        if (playerDead)
        {
            Instantiate(DeathScreen, canvas.transform);
        }
	}
}
