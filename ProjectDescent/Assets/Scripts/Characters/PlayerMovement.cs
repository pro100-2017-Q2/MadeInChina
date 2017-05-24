using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 1;
    //private Rigidbody2D rig;
    private SpriteRenderer spr;
    Vector2 velocity;

    void Start()
    {

        //rig = GetComponentInChildren<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        //rig.MovePosition(new Vector2(transform.position.x, transform.position.z) + velocity * Time.deltaTime);
        spr.sprite. = new Vector2(transform.position.x, transform.position.z) + velocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
    }
}
