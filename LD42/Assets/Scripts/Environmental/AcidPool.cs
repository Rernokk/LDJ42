using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour {
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerContoller>().Damage(10f * Time.deltaTime);
		}
	}
}
