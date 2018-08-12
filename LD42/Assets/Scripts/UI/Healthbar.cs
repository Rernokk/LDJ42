using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	Enemy_Stats tracked;
	PlayerContoller player;
	[SerializeField]
	Image img;

	public Enemy_Stats Target {
		get {
			return tracked;
		}

		set {
			tracked = value;
		}
	}

	void Start() {
		if (img == null)
		{
			img = transform.Find("Canvas/Healthbar").gameObject.GetComponent<Image>();
			img.material = new Material(transform.Find("Canvas/Healthbar").gameObject.GetComponent<Image>().material);
		} else {
			img.material = new Material(img.material);
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();
		}
	}

	void LateUpdate(){
		if (tracked != null)
		{
			img.material.SetFloat("_Value", tracked.HealthPercent);
		} else if (player != null){
			img.material.SetFloat("_Value", player.HealthPercent);
		}
	}
}
