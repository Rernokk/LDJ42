using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	#region Variables
	List<Node> neighbors = new List<Node>();
	bool isActive = true;
	bool visited = false;
	Node backNode = null;
	#endregion

	#region Properties
	public bool Activated {
		get {
			return isActive;
		}

		set {
			isActive = value;
		}
	}
	public bool BeenVisited{
		get {
			return visited;
		}
		set {
			visited = value;
		}
	}
	public Node BackNode {
		get {
			return backNode;
		}
		set {
			backNode = value;
		}
	}
	public List<Node> Neighbors {
		get{
			return neighbors;
		}
		set {
			neighbors = value;
		}
	}
	#endregion

	#region Public Methods
	public void AddNeighbor(Node node){
		neighbors.Add(node);
	}

	public void DisableCollider(){
		GetComponent<Collider2D>().enabled = false;
	}

	public void ResetNode()
	{
		backNode = null;
		visited = false;
	}
	#endregion

	#region Private Methods
	void Update(){
		if (isActive){
			foreach (Node n in neighbors)
			{
				if (n.isActive)
				{
					Debug.DrawLine(transform.position, n.transform.position, Color.red);
				}
			}
		}
	}
	#endregion
}
