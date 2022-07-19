using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
	public ParticleSystem particles;

	void Start() {
		
	}

	void Update() {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Enemy") {
			if(--Enemy.enemyHP == 0) {
				other.gameObject.GetComponent<Animator>().SetTrigger("Death");
				ParticleSystem particle = Instantiate(particles, other.gameObject.transform.position, Quaternion.identity);
				particle.Play();
			}
			else {
				other.gameObject.GetComponent<Animator>().SetBool("IsDamaged", true);
			}
		}
	}
}
