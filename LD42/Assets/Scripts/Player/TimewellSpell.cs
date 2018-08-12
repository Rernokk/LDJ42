using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimewellSpell : Spellcast
{
	[SerializeField]
	float Radius, Strength, Duration;

	[SerializeField]
	GameObject timewellPrefab;

	public override void CastSpell()
	{
		if (CooldownTimer <= 0)
		{
			CooldownTimer = CooldownTime;
			print("Casting Timewell");
			Vector3 tarPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tarPos.z = 0;
			TimewellPoint point = Instantiate(timewellPrefab, tarPos, Quaternion.identity).GetComponent<TimewellPoint>();
			point.Radius = Radius;
			point.Weight = Strength;
			Destroy(point.gameObject, Duration);
		}
	}
}
