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

	public Vector2 MapDimensions{
		get {
			return new Vector2(mapWidth, mapHeight);
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
				if (coll != null && coll.GetComponent<Node>() != null)
				{
					coll.GetComponent<Node>().Activated = false;
					coll.enabled = false;
				}
			}
		}
	}

	void DisableNodeColliders()
	{
		for (int i = 0; i < mapWidth; i++){
			for (int j = 0; j < mapHeight; j++){
				nodes[i,j].DisableCollider();
				if (!nodes[i,j].Activated){
					foreach (Node n in nodes[i,j].Neighbors){
						n.Neighbors.Remove(nodes[i, j]);
					}
					Destroy(nodes[i, j].gameObject);
					nodes[i, j] = null;
				}
			}
		}
	}

	void ResetNodePathfinding()
	{
		foreach (Node node in nodes)
		{
			if (node != null)
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
		if (startPosition != null)
		{
			startPosition.BackNode = null;
			startPosition.BeenVisited = true;
		}
		
		//Add to search queue
		toVisit.Add(startPosition);

		//If Goals are not active, skip.
		if (startPosition == null || endGoal == null || !endGoal.Activated || !startPosition.Activated)
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

			if (currNode == endGoal){
				while (currNode.BackNode != null){
					retVal.Add(currNode.transform.position);
					currNode = currNode.BackNode;
				}
				retVal.Reverse();
				return retVal;
			} else {
				for (int i = 0; i < currNode.Neighbors.Count; i++){
					if (!currNode.Neighbors[i].BeenVisited)
					{
						currNode.Neighbors[i].BeenVisited = true;
						currNode.Neighbors[i].BackNode = currNode;
						toVisit.Add(currNode.Neighbors[i]);
					}
				}
			}
		}
		return retVal;
	}

	public List<Vector3> GenPath (Vector3 start, Vector3 end){

		List<Vector3> path = new List<Vector3>();
		Node startNode = nodes[Mathf.Clamp(Mathf.RoundToInt(start.x), 0, mapWidth - 1), Mathf.Clamp(Mathf.RoundToInt(start.y), 0, mapHeight - 1)];
		ResetNodePathfinding();

		Queue<Node> q = new Queue<Node>();
		q.Enqueue(startNode);
		startNode.BeenVisited = true;
		
		while (q.Count > 0){
			Node temp = q.Dequeue();

			//Found End
			if (temp.transform.position == end){
				print("Found End");
				while (temp.BackNode != null){
					path.Add(temp.transform.position);
					temp = temp.BackNode;
				}
				path.Reverse();
				return path;
			}

			for (int i = 0; i < temp.Neighbors.Count; i++){
				if (!temp.Neighbors[i].BeenVisited){
					temp.Neighbors[i].BeenVisited = true;
					temp.Neighbors[i].BackNode = temp;
					q.Enqueue(temp.Neighbors[i]);
				}
			}
		}
		return path;
	}
	#endregion
}
