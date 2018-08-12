using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholePoint : MonoBehaviour
{
	#region Variables
	[SerializeField]
	float myRadius = 3f, myDamage, pullStrength;

	[SerializeField]
	LayerMask mask;
	#endregion

	#region Properties
	public float Radius
	{
		get
		{
			return myRadius;
		}
		set
		{
			myRadius = value;
		}
	}
	public float Weight
	{
		get
		{
			return pullStrength;
		}

		set
		{
			pullStrength = value;
		}
	}

	public float Damage
	{
		get
		{
			return myDamage;
		}

		set
		{
			myDamage = value;
		}
	}
	#endregion

	#region Methods
	void Update()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, myRadius, mask);
		foreach (Collider2D col in colls)
		{
			if (col.GetComponent<Enemy_Stats>() != null)
			{
				col.GetComponent<Enemy_Stats>().Damage(myDamage * Time.deltaTime);
				col.transform.position = Vector2.Lerp(col.transform.position, transform.position, .02f);
			} else if (col.GetComponent<Enemy_Projectile>() != null){
				col.GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position).normalized * 5f);
				col.GetComponent<Enemy_Projectile>().DamageEnemy = true;
			}
		}
		DrawRadius();
	}

	void DrawRadius()
	{
		for (int i = -3; i <= 3; i++)
		{
			for (int j = -3; j <= 3; j++)
			{
				Vector2 ray = new Vector2(i, j).normalized * myRadius;
				Debug.DrawRay(transform.position, ray, Color.red);
			}
		}
	}
	#endregion
}
