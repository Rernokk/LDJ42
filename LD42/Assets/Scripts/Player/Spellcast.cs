﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcast : MonoBehaviour {
	protected float CooldownTimer = 3f;

	[SerializeField]
	protected float CooldownTime = 3f;

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
