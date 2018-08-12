using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBehaviour : AttackBehaviour {
	[SerializeField]
	float ProjectileSpeed = 1.0f;

	[SerializeField]
	GameObject projectilePrefab;

	public override void Attack()
	{
		if (attackTimer <= 0)
		{
			attackTimer = secondsPerAttack;
			GameObject obj = Instantiate(projectilePrefab, transform.position + (player.transform.position - transform.position).normalized, Quaternion.identity);
			obj.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * ProjectileSpeed, ForceMode2D.Impulse);

		}
	}
}
