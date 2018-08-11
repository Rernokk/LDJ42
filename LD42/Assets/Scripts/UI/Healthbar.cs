using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	Enemy_Stats tracked;

	public Enemy_Stats Target {
		get {
			return tracked;
		}

		set {
			tracked = value;
		}
	}

	void Start(){
		transform.Find("Canvas/Healthbar").gameObject.GetComponent<Image>().material = new Material(transform.Find("Canvas/Healthbar").gameObject.GetComponent<Image>().material);
	}
}
