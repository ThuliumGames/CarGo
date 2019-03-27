using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour {
	
	public Transform[] Gs;
	
	void Update () {
		//transform.LookAt ((Gs[0].position+Gs[1].position)/2);
		//transform.position = new Vector3 (0, Mathf.Clamp (Vector3.Distance (Gs[0].position, Gs[1].position), 5, 500), 0);
		transform.position = ((Gs[0].position+Gs[1].position)/2);
		transform.Translate (0, 0, Mathf.Clamp (-Vector3.Distance(Gs[0].position,Gs[1].position), -100000, -5));
	}
}
