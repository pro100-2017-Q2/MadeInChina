using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public Camera cam;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
         offset = cam.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        cam.transform.position = player.transform.position + offset;
	}
}
