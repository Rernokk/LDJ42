using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	Transform targetAnchor;
	void Start () {
		targetAnchor = GameObject.FindGameObjectWithTag("Player").transform.Find("CameraAnchor");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, targetAnchor.transform.position, .5f);
	}
}
