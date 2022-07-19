using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeLife : MonoBehaviour {
	float life = 0.8f;
	
	void Update() {
		life -= Time.deltaTime;

		if(life <= 0) Destroy(gameObject);
	}
}
