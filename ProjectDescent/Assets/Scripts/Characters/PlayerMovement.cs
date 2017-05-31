using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //public float speed = 1;
    private Rigidbody rig;
    Vector3 velocity;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * LevelController.player.MoveSpeed;
        rig.MovePosition(transform.position + velocity * Time.deltaTime);
    }

}
