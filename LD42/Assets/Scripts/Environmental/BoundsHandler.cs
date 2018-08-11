using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsHandler : MonoBehaviour {
	AIGrid gameboard;
	// Use this for initialization
	void Start () {
		gameboard = GameObject.FindGameObjectWithTag("AIManager").GetComponent<AIGrid>();
		transform.position = gameboard.MapDimensions * .5f - new Vector2(.5f, .5f);
		BoxCollider2D top = gameObject.AddComponent<BoxCollider2D>();
		BoxCollider2D bot = gameObject.AddComponent<BoxCollider2D>();
		BoxCollider2D lft = gameObject.AddComponent<BoxCollider2D>();
		BoxCollider2D rgt = gameObject.AddComponent<BoxCollider2D>();
		top.size = new Vector2(gameboard.MapDimensions.x, .5f);
		bot.size = new Vector2(gameboard.MapDimensions.x, .5f);
		lft.size = new Vector2(.5f, gameboard.MapDimensions.y);
		rgt.size = new Vector2(.5f, gameboard.MapDimensions.y);
		top.offset = new Vector2(0, gameboard.MapDimensions.y * .5f);
		bot.offset = new Vector2(0, -gameboard.MapDimensions.y * .5f);
		lft.offset = new Vector2(gameboard.MapDimensions.x * .5f, 0);
		rgt.offset = new Vector2(-gameboard.MapDimensions.x * .5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
