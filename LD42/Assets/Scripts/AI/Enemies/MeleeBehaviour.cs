using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : AttackBehaviour {
	public override void Attack()
	{
		if (attackTimer <= 0){
			attackTimer = secondsPerAttack;
			player.Damage(Damage);
		}
	}
}
