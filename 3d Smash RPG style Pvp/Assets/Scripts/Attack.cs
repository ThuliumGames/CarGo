using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
	
	public Transform ECol;
	
	bool CanMH;
	bool HA;
	float Pow;
	
	public Text t;
	public int Health = 10;
	
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
		
		if (Health <= 0) {
			if (GetComponentInParent<Move>().Player == 0) {
				Application.LoadLevel("End1");
			}
			if (GetComponentInParent<Move>().Player == 1) {
				Application.LoadLevel("End2");
			}
		}
		
		t.text = ""+Health;
		
		if (!GetComponentInParent<Move>().enabled) {
			if (CanMH) {
				if (HA) {
					Health -= 2;
				} else {
					--Health;
				}
				CanMH = false;
			}
		} else {
			CanMH = true;
		}
	}
	
	void OnTriggerEnter (Collider C) {
		print (C);
		if (C.transform == ECol.transform) {
			Pow = 7;
			HA = false;
			if (GetComponentInParent<Move>().Anim.GetBool ("Swing2")) {
				Pow = 15;
				HA = true;
			}
			ECol.GetComponentInChildren<Move>().enabled = false;
			ECol.Translate (0, 0.6f, 0);
			ECol.GetComponent<Rigidbody>().velocity = ((GetComponentInParent<Move>().transform.forward * Pow) + (Vector3.up * (Pow/1.5f)));
			Invoke ("Reen", 1.4f);
			GetComponentInChildren<BoxCollider>().enabled = false;
		}
	}
	
	void Reen () {
		ECol.GetComponentInChildren<Move>().enabled = true;
	}
}
