using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Pathfinding : MonoBehaviour
{
	[SerializeField]
	float MovementSpeed;

	[SerializeField]
	Vector2 target;

	AIGrid pathManager;
	List<Vector3> currentPath = new List<Vector3>();
	Rigidbody2D rgd2d;
	float pathTimer = 3f;

	void Start()
	{
		pathManager = GameObject.FindGameObjectWithTag("AIManager").GetComponent<AIGrid>();
		rgd2d = GetComponent<Rigidbody2D>();
		rgd2d.gravityScale = 0;
		GetNewTarget();
	}

	void Update()
	{
		if (currentPath.Count > 0)
		{
			rgd2d.velocity = (currentPath[0] - transform.position).normalized * MovementSpeed;
			if (Vector3.Distance(transform.position, currentPath[0]) < .45f)
			{
				currentPath.RemoveAt(0);
			}
		}
		else
		{
			rgd2d.velocity = Vector2.zero;
			if (pathTimer <= 0)
			{
				pathTimer = Random.Range(.2f, .4f);
				GetNewTarget();
			}
			else
			{
				pathTimer -= Time.deltaTime;
			}
		}
	}

	void GetNewTarget()
	{
		if (pathManager.MapReady)
		{
			currentPath.Clear();
			Vector3 tar = new Vector3(Random.Range(0f, 14f), Random.Range(0, 14f), 0);
			if (tar != transform.position)
			{
				currentPath = pathManager.BestFirst(transform.position, tar);
			}
		}
	}
}
