using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcast : MonoBehaviour {
	protected float CooldownTimer = 0f;

	[SerializeField]
	protected float CooldownTime = 0f;

	public virtual void CastSpell(){
		if (CooldownTimer <= 0)
		{
			Debug.Log("Spell Cast!");
			CooldownTimer = CooldownTime;
		}
	}

	public virtual void Tick(){
		if (CooldownTimer > 0){
			CooldownTimer -= Time.deltaTime;
		}
	}
}
