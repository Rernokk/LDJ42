using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeSpell : Spellcast{
	[SerializeField]
	float Radius, Strength, Damage, Duration;

	[SerializeField]
	GameObject blackholePrefab;

	public override void CastSpell()
	{
		if (CooldownTimer <= 0){
			CooldownTimer = CooldownTime;
			print("Casting Black Hole");
			Vector3 tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tarPos.z = 0;
			BlackholePoint point = Instantiate(blackholePrefab, tarPos, Quaternion.identity).GetComponent<BlackholePoint>();
			point.Radius = Radius;
			point.Weight = Strength;
			point.Damage = Damage;
			Destroy(point.gameObject, Duration);
		}
	}
}
