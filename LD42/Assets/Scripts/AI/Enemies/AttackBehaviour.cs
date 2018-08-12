using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {
	[SerializeField]
	protected float secondsPerAttack = 1.0f;
	protected float attackTimer = 0.0f;
	protected PlayerContoller player;

	[SerializeField]
	protected float Damage;

	protected void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
	}

	public virtual void Attack(){
		attackTimer = secondsPerAttack;
	}

	protected void Update(){
		if (attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
	}
}
