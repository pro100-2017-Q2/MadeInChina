using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    public int enemiesKilled = 0;

    public Collider attackCollider;

    bool usingSword = false;
    int swordDamage = 1;

    SpriteRenderer sr;

    public Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    void Start()
    {
        tile = LevelController.level.WorldToTile(transform.position);
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("Death");
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (usingSword)
            {
                usingSword = false;
                AttackDamage -= swordDamage;
                sr.sprite = Resources.Load<Sprite>("Sprites/Player/PlayerIdleFront");
                //sr.sprite = spriteDictionary["PlayerIdleFront"];
            }
            else
            {
                usingSword = true;
                AttackDamage += swordDamage;
                sr.sprite = Resources.Load<Sprite>("Sprites/Player/PlayerSwordFront");
                //sr.sprite = spriteDictionary["PlayerSwordFront"];
            }
        }

        tile = LevelController.level.WorldToTile(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack!!");
            Vector3 mouseDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Instantiate(attackCollider, (transform.position - mouseDir), Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collsion: " + col);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!! Attack!!");
            col.gameObject.GetComponentInParent<Enemy>().TakeDamage(AttackDamage);
        }
    }
}
