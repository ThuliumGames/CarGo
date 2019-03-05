using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
	
	public Transform Camera;
	public Rigidbody2D RB;
	public float Speed;
	
	bool onGround;
	
	void Update () {
		Camera.position = transform.position + new Vector3 (0, 1, -10);
		if (onGround) {
			print ("OnGround");
			RB.AddRelativeForce (new Vector2 (Input.GetAxis("Horizontal")*Speed, 0));
		} else {
			print ("OffGround");
			RB.AddTorque (Input.GetAxis("Horizontal")*Speed/50);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collision) {
		onGround = true;
	}
	
	void OnTriggerExit2D(Collider2D collision) {
		onGround = false;
	}
}
