using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
	[SerializeField]
	int DamageAmount = 100;
	void OnTriggerEnter2D(Collider2D coll){
		Enemy_Stats other = coll.GetComponent<Enemy_Stats>();
		if (other != null){
			other.Damage(DamageAmount);
		}
		Destroy(gameObject);
	}
}
