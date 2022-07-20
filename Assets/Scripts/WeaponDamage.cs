using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
	CurrentWeapon cw;
	public ParticleSystem particles;

	void Start() {
		cw = GetComponent<CurrentWeapon>();
	}

	void Update() {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy") {
			if(cw.hasWeapon) {
				Transform t = other.gameObject.transform;
				Animator goAnim = other.gameObject.GetComponent<Animator>();
				
				if(--other.gameObject.GetComponent<Enemy>().enemyHP == 0) {
					goAnim.SetTrigger("Death");
					ParticleSystem particle = Instantiate(particles, t.position, Quaternion.identity);
					particle.Play();
				}
				else {
					other.gameObject.GetComponent<Enemy>()._isHit = false;
					goAnim.SetBool("IsDamaged", true);
				}
			}
		}
	}
}
