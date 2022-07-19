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
	
	void FixedUpdate() {
		Vector3 targetPos = new Vector3(Mathf.Clamp(player.position.x, -6.88f, 14.92f), Mathf.Clamp(player.position.y, -8.33f, 8.26f), 1);
		cam.position = Vector3.Lerp(cam.position, targetPos + offset, 3f * Time.fixedDeltaTime);
	}
}
