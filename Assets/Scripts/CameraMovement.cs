using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[SerializeField] Transform player;
	[SerializeField] Vector3 offset;
	Transform cam;

	void Start() {
		cam = transform;
	}
	
	void Update() {
		cam.position = player.position + offset;
	}
}
