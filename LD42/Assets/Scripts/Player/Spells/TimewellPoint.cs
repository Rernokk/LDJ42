using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimewellPoint : MonoBehaviour
{
	#region Variables
	[SerializeField]
	float myRadius = 3f, maxStrength;

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
			return maxStrength;
		}

		set
		{
			maxStrength = value;
		}
	}
	#endregion

	#region Methods

	void Start(){
	}

	void Update()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, myRadius, mask);
		foreach (Collider2D col in colls)
		{
			if (col.GetComponent<Enemy_Pathfinding>() != null)
			{
				col.GetComponent<Enemy_Pathfinding>().SetSpeed(Vector2.Distance(transform.position, col.transform.position) / Radius, 3f);
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
