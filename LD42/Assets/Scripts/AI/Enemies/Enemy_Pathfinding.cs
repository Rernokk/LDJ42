using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Pathfinding : MonoBehaviour
{
	[SerializeField]
	float MovementSpeed;

	[SerializeField]
	List<Vector3> currentPath = new List<Vector3>();

	GameObject targetPlayer;
	AIGrid pathManager;
	Rigidbody2D rgd2d;
	float pathTimer = 3f;
	float attackRange = 1f;

	#region Properties
	public float AttackRange {
		get {
			return attackRange;
		}
		set{
			attackRange = value;
		}
	}
	#endregion

	void Start()
	{
		pathManager = GameObject.FindGameObjectWithTag("AIManager").GetComponent<AIGrid>();
		rgd2d = GetComponent<Rigidbody2D>();
		rgd2d.gravityScale = 0;
		targetPlayer = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{

		if (Vector3.Distance(transform.position, targetPlayer.transform.position) < attackRange)
		{
			rgd2d.velocity = Vector3.zero;
		}
		else
		{
			RaycastHit2D[] inf = Physics2D.RaycastAll(transform.position, (targetPlayer.transform.position - transform.position).normalized, 10f, LayerMask.NameToLayer("Obstacles"));
			if (Vector3.Distance(transform.position, targetPlayer.transform.position) < 10f && inf.Length == 0)
			{
				rgd2d.velocity = (targetPlayer.transform.position - transform.position).normalized * MovementSpeed;
			}
			else
			{
				if (currentPath.Count > 0)
				{
					rgd2d.velocity = (currentPath[0] - transform.position).normalized * MovementSpeed;
					if (Vector2.Distance(transform.position, currentPath[0]) < .15f)
					{
						currentPath.RemoveAt(0);
					}
					currentPath = pathManager.BestFirst(transform.position, targetPlayer.transform.position);
				}
				else
				{
					currentPath = pathManager.BestFirst(transform.position, targetPlayer.transform.position);
				}
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

	bool CanSeePlayer(){
		if (Vector2.Distance(transform.position, targetPlayer.transform.position) > 5f){
			return false;
		}
		RaycastHit2D inf = Physics2D.Raycast(transform.position, (targetPlayer.transform.position - transform.position).normalized, 10f, LayerMask.NameToLayer("Obstacles"));
		if (inf.transform == null){
			print("No Issues, can see");
			return true;
		}
		return false;
	}
}
