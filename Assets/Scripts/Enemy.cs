using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Animator anim;
	public static float enemyHP = 3;

	void Start() {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
	}
	
	protected void destroyEnemyGameObject() {
		Destroy(gameObject);
	}

	protected void damagedAnimDone() {
		anim.SetBool("IsDamaged", false);
	}
}
