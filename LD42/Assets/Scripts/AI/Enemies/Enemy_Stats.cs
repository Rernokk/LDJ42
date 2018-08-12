using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour {
	#region Variable
	[SerializeField]
	protected float maxHealth;

	[SerializeField]
	protected bool useHealthBar;

	[SerializeField]
	protected GameObject healthBar;

	[SerializeField]
	protected float attackRange = 1f;

	[SerializeField]
	protected GameObject acidPool;

	[SerializeField]
	protected float poolSizeMod = 1.0f;

	protected float currentHealth;
	protected Enemy_Pathfinding pathfinder;
	#endregion

	#region Properties
	public float HealthPercent {
		get {
			return (float)currentHealth / maxHealth;
		}
	}
	#endregion

	#region Protected Methods
	protected void Start () {
		currentHealth = maxHealth;
		pathfinder = GetComponent<Enemy_Pathfinding>();
		pathfinder.AttackRange = attackRange;
		if (useHealthBar){
			healthBar = Instantiate(healthBar, transform.position, Quaternion.identity);
			healthBar.transform.parent = transform;
			healthBar.GetComponent<Healthbar>().Target = this;
		}
	}
	
	protected void Update () {
		if (currentHealth <= 0){
			Die();
		}
	}

	protected void Die(){
		Instantiate(acidPool, transform.position, Quaternion.identity).transform.localScale *= poolSizeMod;
		Destroy(gameObject);
	}
	#endregion

	public void Damage (float amount){
		currentHealth -= amount;
		if (currentHealth <= 0){
			Die();
		}
	}
}
