using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour {
	[SerializeField]
	int maxHealth;
	int currentHealth;

	[SerializeField]
	bool useHealthBar;

	[SerializeField]
	GameObject healthBar;

	void Start () {
		currentHealth = maxHealth;
		if (useHealthBar){
			healthBar = Instantiate(healthBar, transform.position, Quaternion.identity);
			healthBar.transform.parent = transform;
			healthBar.GetComponent<Healthbar>().Target = this;
		}
	}
	
	void Update () {
		if (currentHealth <= 0){
			Die();
		}
	}

	void Die(){
		Destroy(gameObject);
	}
}
