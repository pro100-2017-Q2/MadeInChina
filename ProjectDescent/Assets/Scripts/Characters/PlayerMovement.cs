using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 200;
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float moveX = hAxis * speed * Time.deltaTime;
        float moveY = vAxis * speed * Time.deltaTime;
        //rig.MovePosition(transform.position + movement);
        rig.AddForce(moveX, 0f, moveY);
    }
}
