using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    public int enemiesKilled = 0;

    public Collider attackColliderPrefab;
    Collider attack;
    int attackTimer = 0;

    int swordDamage = 1;

    Direction currentDir = Direction.Front;
    PlayerItem currentItem = PlayerItem.Idle;

    public List<GameObject> spriteDictionary = new List<GameObject>();

    void Start()
    {
        tile = LevelController.level.WorldToTile(transform.position);
    }

    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Death");
            Destroy(gameObject);
        }

        ChangeSprite();

        tile = LevelController.level.WorldToTile(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            int deltaY = 0;
            int deltaX = 0;
            if (currentDir == Direction.Left)
                deltaX = -1;
            if (currentDir == Direction.Right)
                deltaX = 1;

            if (currentDir == Direction.Back)
                deltaY = 1;
            if (currentDir == Direction.Front)
                deltaY = -1;
            attack = Instantiate(attackColliderPrefab, (new Vector3(transform.position.x + deltaX, transform.position.y + .5f, transform.position.z + deltaY)), Quaternion.identity, transform);
        }

        if(attack != null)
        {
            attackTimer++;
            if (attackTimer > 3)
            {
                Destroy(attack.gameObject);
                attackTimer = 0;
            }
        }
        
    }

    void ChangeSprite()
    {
        //Item Change
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentItem == PlayerItem.Sword)
            {
                currentItem = PlayerItem.Idle;
                AttackDamage -= swordDamage;
            }
            else
            {
                currentItem = PlayerItem.Sword;
                AttackDamage += swordDamage;
            }
        }

        //Direction Change
        if (Input.GetKeyDown(KeyCode.D) && currentDir != Direction.Right)
        {
            currentDir = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentDir != Direction.Front)
        {
            currentDir = Direction.Front;
        }
        else if (Input.GetKeyDown(KeyCode.A) && currentDir != Direction.Left)
        {
            currentDir = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.W) && currentDir != Direction.Back)
        {
            currentDir = Direction.Back;
        }

        foreach (GameObject go in spriteDictionary)
        {
            if (go.name != "Player" + currentItem + currentDir)
            {
                go.SetActive(false);
            }
            else if (go.name == "Player" + currentItem + currentDir)
            {
                go.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponentInParent<Enemy>().TakeDamage(AttackDamage);
    }
}

public enum Direction
{
    Front,
    Left,
    Back,
    Right
}

public enum PlayerItem
{
    Idle,
    Sword,
    Trouch
}
