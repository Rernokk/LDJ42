using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGrid : MonoBehaviour {
	GameObject[,] nodes;

	[SerializeField]
	GameObject nodePrefab;

	[SerializeField]
	float stepDistance;
	
	[SerializeField]
	int mapWidth, mapHeight;

	void Start(){
		nodes = new GameObject[mapWidth, mapHeight];
		for (int i = 0; i < mapWidth; i++){
			for (int j = 0; j < mapHeight; j++){
				nodes[i, j] = Instantiate(nodePrefab, new Vector3(i, j, 0), Quaternion.identity);
			}
		}
	}
}
