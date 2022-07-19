using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] LayerMask weaponOnGroundMask;
	[SerializeField] Transform weaponPosition;
	[SerializeField] CurrentWeapon cw;
	GameObject currentWeapon;
	Animator anim;
	BoxCollider2D bc;
	Rigidbody2D player;
	Transform player_;
	float speed = 7f;
	float x, y;
	float prevX = 0, prevY = -1;
	bool _canAttack = true;
	
	void Start() {
		player = GetComponent<Rigidbody2D>();
		anim  = GetComponent<Animator>();
		bc = GetComponent<BoxCollider2D>();
		player_ = transform;
	}

	void Update() {
		if(_canAttack) {
			player.velocity = new Vector2(x, y) * speed;
			x = Input.GetAxisRaw("Horizontal");
			y = Input.GetAxisRaw("Vertical");
		}
		else player.velocity = Vector2.zero;

		if(cw.hasWeapon && Input.GetMouseButtonDown(0) && _canAttack) {
			player_.localScale = new Vector3(1 * player_.localScale.x, 1, 1);
			cw.getAnim("Attack");
			cw.hideWeapon(true, true);
			anim.SetTrigger("ScytheAttack");
		}

		if(x == 0 && y == 0) {
			anim.SetBool("Running", false);
			anim.SetBool("SideRunning", false);
			anim.SetBool("BackRunning", false);
			
			if(prevX != 0 && prevY == 0) {
				anim.SetBool("SideIdle", true);

				if(prevX == 1) player_.localScale = new Vector3(-1, 1, 1);
				else {
					if(prevX == -1) player_.localScale = Vector3.one;
				}
			}
			else {
				if(prevY == 1) anim.SetBool("BackIdle", true);
				else {
					if(prevY == -1) anim.SetBool("Idle", true);
				}
			}
		}
		else {
			anim.SetBool("Idle", false);
			anim.SetBool("BackIdle", false);
			anim.SetBool("SideIdle", false);

			if(y == 1) setRunningAnim(y, false, true, false);
			else if(y == -1) setRunningAnim(y, true, false, false);
			else {
				setRunningAnim(0, false, false, true);
				
				if(x == 1) {
					prevX = x;
					player_.localScale = new Vector3(-1, 1, 1);
				}
				else {
					if(x == -1) {
						prevX = x;
						player_.localScale = Vector3.one;
					}
				}
			}
		}

		pickUpWeapon();
		cw.dropWeapon(prevX, player_.localScale.x);
	}
	
	void setRunningAnim(float y, bool front, bool back, bool side) {
		prevY = y;
		anim.SetBool("Running", front);
		anim.SetBool("BackRunning", back);
		anim.SetBool("SideRunning", side);
	}

	public void canAttack() {
		_canAttack = true;
		anim.SetTrigger("ToIdle");
	}

	public void cannotAttack() {
		_canAttack = false;
	}

	void pickUpWeapon() {
		RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector3.right * player_.localScale.x, 0.5f, weaponOnGroundMask);

		if(Input.GetKeyDown(KeyCode.E)) {
			if(hit) {
				GameObject go = hit.collider.gameObject;
				currentWeapon = go;
				Transform go_ = go.transform;
				cw.hasWeapon = true;
				cw.currentWeapon = go;
				cw.grabWeapon(weaponPosition, prevX, player_.localScale.x);
			}
		}
	}
}
