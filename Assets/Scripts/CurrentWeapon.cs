using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapon : MonoBehaviour {
	public bool hasWeapon { get; set; }
	public GameObject currentWeapon { get; set; }
	
	public void grabWeapon(Transform weaponPosition, float prevX, float playerLocalScaleX) {
		currentWeapon.transform.parent = weaponPosition;
		currentWeapon.transform.position = weaponPosition.position;
		currentWeapon.transform.localScale = new Vector3(prevX < 0 ? 0.7f : -0.7f, 0.7f * playerLocalScaleX, 0.7f);
		hideWeapon(false, false);
	}

	public void dropWeapon(float prevX, float playerLocalScaleX) {
		if(Input.GetKeyDown(KeyCode.G)) {
			if(hasWeapon) {
				currentWeapon.transform.rotation = Quaternion.Euler(0, 0, 77);
				currentWeapon.transform.localScale = new Vector3(prevX < 0 ? 0.7f : -0.7f, 0.7f * playerLocalScaleX, 0.7f);
				hideWeapon(true, true);
				currentWeapon.transform.parent = null;
				currentWeapon = null;
				hasWeapon = false;
			}
		}
	}

	public void getAnim(string anim) {
		currentWeapon.GetComponent<Animator>().SetTrigger(anim);
	}

	public void hideWeapon(bool spriteHide, bool bcHide) {
		currentWeapon.GetComponent<SpriteRenderer>().enabled = spriteHide;
		currentWeapon.GetComponent<BoxCollider2D>().enabled = bcHide;
	}

	protected void onWeaponBoxCollider() {
		currentWeapon.GetComponent<BoxCollider2D>().enabled = true;
	}
	
	protected void offWeaponBoxCollider() {
		currentWeapon.GetComponent<BoxCollider2D>().enabled = false;
	}

	protected void offScytheAttackAnim() {
		currentWeapon.GetComponent<Animator>().SetTrigger("ToIdle");
		hideWeapon(false, false);
	}
}
