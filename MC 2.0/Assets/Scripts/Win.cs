using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	
	public Canvas C;
	public GameObject P1;
	public GameObject P2;
	
	public string NextLevel;
	
	void Update () {
		if (C.enabled) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				Application.LoadLevel(NextLevel);
			}
		}
	}
	
	void OnTriggerEnter2D () {
		C.enabled = true;
		P1.SetActive(false);
		P2.SetActive(false);
	}
}
