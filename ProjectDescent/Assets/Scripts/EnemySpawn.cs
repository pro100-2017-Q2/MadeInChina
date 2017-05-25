using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {


    //add multiple to one game object
    public GameObject[] enemies;


    //boundries for how long we want to spawn objects and
    //as well as boundries
    public Vector3 spawnValues;


    //
    public float spawnWait;

    //time increments when we want to spawn are object to be in
    public float spawnMostWait;

    public float spawnLeastWait;

    //
    public int startWait;

    public bool stop;

    int randEnemy;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        spawnSomething();
        Level = FindObjectOfType<LevelGeneration>();
        Level.Rooms
        */
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

}
