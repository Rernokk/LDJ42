using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour {
	public float Damage = 10f;

	bool canDamageEnemy = false;

	public bool DamageEnemy {
		get {
			return canDamageEnemy;
		}

		set {
			canDamageEnemy = value;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy"){
			if (canDamageEnemy){
				other.GetComponent<Enemy_Stats>().Damage(Damage);
				Destroy(gameObject);
			}
		} else {
			if (other.tag == "Player"){
				other.GetComponent<PlayerContoller>().Damage(Damage);
			}
			Destroy(gameObject);
		}
	}
}
