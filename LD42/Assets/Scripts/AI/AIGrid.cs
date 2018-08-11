using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGrid : MonoBehaviour
{
	#region Variables
	Node[,] nodes;
	bool mapReady = false;

	[SerializeField]
	GameObject nodePrefab;

	[SerializeField]
	float stepDistance;

	[SerializeField]
	int mapWidth, mapHeight;

	[SerializeField]
	ContactFilter2D contactFilter;
	#endregion

	#region Properties
	public bool MapReady {
		get {
			return mapReady;
		}
		set {
			mapReady = value;
		}
	}
	#endregion

	#region Private Methods
	void Start()
	{
		nodes = new Node[mapWidth, mapHeight];
		SpawnNodes();
		LinkNodes();
		BlockNodes();
		DisableNodeColliders();
		mapReady = true;
	}

	void SpawnNodes()
	{
		GameObject root = new GameObject("NodeRoot");
		for (int i = 0; i < mapWidth; i++)
		{
			for (int j = 0; j < mapHeight; j++)
			{
				nodes[i, j] = Instantiate(nodePrefab, new Vector3(i, j, 0), Quaternion.identity).GetComponent<Node>();
				nodes[i, j].transform.parent = root.transform;
			}
		}
	}

	void LinkNodes()
	{
		for (int i = 0; i < mapWidth; i++)
		{
			for (int j = 0; j < mapHeight; j++)
			{
				for (int a = -1; a <= 1; a++)
				{
					for (int b = -1; b <= 1; b++)
					{
						if (i + a >= 0 && i + a < mapWidth && j + b >= 0 && j + b < mapHeight && (a != 0 || b != 0))
						{
							nodes[i, j].AddNeighbor(nodes[i + a, j + b]);
						}
					}
				}
			}
		}
	}

	void BlockNodes()
	{
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacles");

		foreach (GameObject obstacle in obstacles)
		{
			Collider2D[] collisions = new Collider2D[64];
			obstacle.GetComponent<Collider2D>().OverlapCollider(contactFilter, collisions);
			foreach (Collider2D coll in collisions)
			{
				if (coll != null)
				{
					coll.GetComponent<Node>().Activated = false;
					coll.enabled = false;
				}
			}
		}
	}

	void DisableNodeColliders()
	{
		foreach (Node node in nodes)
		{
			node.DisableCollider();
		}
	}

	void ResetNodePathfinding()
	{
		foreach (Node node in nodes)
		{
			node.ResetNode();
		}
	}
	#endregion


	#region Public Methods
	public List<Vector3> BestFirst(Vector3 start, Vector3 end)
	{
		//Reset Graph
		ResetNodePathfinding();

		//Establish Variables
		List<Vector3> retVal = new List<Vector3>();
		List<Node> toVisit = new List<Node>();
		Node currNode = null;
		Node startPosition = nodes[Mathf.Clamp(Mathf.RoundToInt(start.x), 0, mapWidth-1), Mathf.Clamp(Mathf.RoundToInt(start.y), 0, mapHeight - 1)];
		Node endGoal = nodes[Mathf.Clamp(Mathf.RoundToInt(end.x), 0, mapWidth - 1), Mathf.Clamp(Mathf.RoundToInt(end.y), 0, mapHeight - 1)];

		//Set "Start Node" correctly.
		startPosition.BackNode = null;
		startPosition.BeenVisited = true;
		
		//Add to search queue
		toVisit.Add(startPosition);

		//If Goals are not active, skip.
		if (!endGoal.Activated || !startPosition.Activated || startPosition == null || endGoal == null)
		{
			print("Node Invalid");
			return retVal;
		}

		//While Nodes left to search.
		while (toVisit.Count > 0)
		{
			//Sort by Distance to Goal (Best)
			toVisit.Sort((q1, q2) => Vector3.Distance(q1.transform.position, endGoal.transform.position).CompareTo(Vector3.Distance(q2.transform.position, endGoal.transform.position)));

			//Pop Node & Search
			currNode = toVisit[0];
			toVisit.RemoveAt(0);
			
			//For each neighbor of the current node
			foreach (Node neighbor in currNode.Neighbors)
			{

				//If Node is Active, Check it.
				if (neighbor.Activated)
				{
					//Check if neighbor is the goal
					if (neighbor == endGoal)
					{
						print("Found Node, Backing");
						neighbor.BackNode = currNode;
						neighbor.BeenVisited = true;
						currNode = neighbor;
						while (currNode != null)
						{
							retVal.Add(currNode.transform.position);
							currNode = currNode.BackNode;
						}
						retVal.Reverse();
						return retVal;
					}
					//Neighbor is not our goal and has not been visited.
					else if (!neighbor.BeenVisited)
					{
						toVisit.Add(neighbor);
						neighbor.BackNode = currNode;
						neighbor.BeenVisited = true;
						Debug.DrawLine(currNode.transform.position, neighbor.transform.position, Color.blue, 1f);
					}
				}

				//Else, Mark as visited and skip.
				else
				{
					neighbor.BeenVisited = true;
				}
			}
		}
		return retVal;
	}
	#endregion
}
