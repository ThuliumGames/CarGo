using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {
	
	public Transform Camera;
	public Rigidbody2D RB;
	public float Speed;
	
	bool onGround;
	
	void Update () {
		Camera.position = transform.position + new Vector3 (2, 1, -10);
		
		if (Input.GetButton("Jump")) {
			Camera.GetComponent<Camera>().orthographicSize = Mathf.Lerp (Camera.GetComponent<Camera>().orthographicSize, 20, 5*Time.deltaTime);
			RB.AddRelativeForce (new Vector2 (10*Speed, 0));
		} else {
			Camera.GetComponent<Camera>().orthographicSize = Mathf.Lerp (Camera.GetComponent<Camera>().orthographicSize, 5, 5*Time.deltaTime);
		}
		
		if (onGround) {
			RB.AddRelativeForce (new Vector2 (Input.GetAxis("Horizontal")*Speed, 0));
		} else {
			RB.AddTorque (Input.GetAxis("Horizontal")*Speed/50);
		}
	}
	
	void OnTriggerStay2D(Collider2D collision) {
		onGround = true;
	}
	
	void OnTriggerExit2D(Collider2D collision) {
		onGround = false;
	}
}
