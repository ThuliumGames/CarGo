using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	
	public Transform ECol;
	
	float Pow;
	
	void OnEnable () {
		GetComponentInParent<Move>().Anim.SetBool ("Swing", false);
		GetComponentInParent<Move>().Anim.SetBool ("Swing2", false);
	}
	
	void Update () {
		if (SSInput.B[GetComponentInParent<Move>().Player] == "Pressed") {
			GetComponentInParent<Move>().Anim.SetBool ("Swing", true);
		}
		if (SSInput.A[GetComponentInParent<Move>().Player] == "Pressed") {
			GetComponentInParent<Move>().Anim.SetBool ("Swing2", true);
		}
	}
	
	void OnTriggerEnter (Collider C) {
		print (C);
		if (C.transform == ECol.transform) {
			Pow = 10;
			if (GetComponentInParent<Move>().Anim.GetBool ("Swing2")) {
				Pow = 15;	
			}
			ECol.GetComponentInChildren<Move>().enabled = false;
			Invoke ("Reen", 1);
			GetComponentInChildren<BoxCollider>().enabled = false;
		}
	}
	
	void Reen () {
		ECol.GetComponentInChildren<Move>().enabled = true;
	}
}
