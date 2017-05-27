using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public Camera cam;

	void Start () {
	}
	
	void Update () {
        cam.transform.position = new Vector3(player.transform.position.x, 25, player.transform.position.z - 35);
    }
}
