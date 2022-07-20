using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField] LayerMask playerMask;
	public bool _isHit = true;
	public int enemyHP = 3;
	GameObject player;
	Animator anim;
	Transform enemy;
	float attackTime = 2f;
	bool canAttack = true;
	bool _isNearPlayer = false;

	void Start() {
		player = GameObject.Find("Player");
		enemy = transform;
		anim = GetComponent<Animator>();
	}

	void Update() {
		// if(_isHit) enemy.position = Vector3.MoveTowards(enemy.position, player.transform.position, 3f * Time.deltaTime);

		if(!_isNearPlayer) {
			if(enemy.position.x < player.transform.position.x) {
				anim.SetTrigger("RightIdle");
				enemy.localScale = new Vector3(-2, 2, 1);
			}
			else {
				anim.SetTrigger("LeftIdle");
				enemy.localScale = new Vector3(2, 2, 1);
			}
		}
		isNearPlayer();
	}
	
	protected void destroyEnemyGameObject() {
		Destroy(gameObject);
	}

	protected void damagedAnimDone() {
		anim.SetBool("IsDamaged", false);
		_isHit = true;
	}

	void isNearPlayer() {
		RaycastHit2D hit = Physics2D.Raycast(enemy.position, Vector2.right * -enemy.localScale.x, 3f, playerMask);
		if(hit.collider != null && canAttack) {
			anim.SetTrigger("Attack");
		}
	}

	protected void continueAttack() {
		canAttack = true;
		Debug.Log("Can Attack");
	}

	protected void stopAttack() {
		canAttack = false;
		_isNearPlayer = true;
		Debug.Log("Cannot Attack");
	}
}
