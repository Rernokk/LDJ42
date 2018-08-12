using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSpell : Spellcast {
	[SerializeField]
	float JumpDistance;

	[SerializeField]
	LayerMask mask;

	public override void CastSpell()
	{
		if (CooldownTimer <= 0)
		{
			CooldownTimer = CooldownTime;
			Debug.Log("Cast Blink");
			Vector3 tar = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tar.z = 0;
			Ray ray = new Ray(transform.position, (tar - transform.position).normalized);
			Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
			RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, JumpDistance, mask);
			print(hits.Length);
			if (hits.Length > 0){
				print("Hit boundary");
				transform.position += (Vector3)((hits[0].point - (Vector2) transform.position) * .8f);
			} else {
				transform.position += ray.direction * JumpDistance;
			}
		}
	}
}
