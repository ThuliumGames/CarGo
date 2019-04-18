using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	public Transform otherPlayer;
	
	public float Speed;
	
	public string Hor;
	public string Ver;
	
	public bool onGround;
	
	public float moveSpeed;
	public float jumpPower;
	
	public LayerMask LMSide;
	public LayerMask LMDown;
	
	void Update () {
		if (onGround) {
			Speed += Input.GetAxisRaw(Hor)*moveSpeed*Time.deltaTime;
			Speed = Mathf.Clamp (Speed, -15, 15);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (Speed, GetComponent<Rigidbody2D>().velocity.y);
			
			if (Input.GetAxisRaw(Ver) > 0.5f) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpPower);
			}
		}
		
		if (Physics2D.BoxCast(transform.position, new Vector2 (0.9f, 0.5f), 0, Vector2.right, 0.05f, LMSide)) {
			Speed = 0;
			transform.position += new Vector3 (-0.01f, 0, 0);
		}
		
		if (Physics2D.BoxCast(transform.position, new Vector2 (0.9f, 0.5f), 0, -Vector2.right, 0.05f, LMSide)) {
			Speed = 0;
			transform.position += new Vector3 (0.01f, 0, 0);
		}
		
		if (Physics2D.BoxCast(transform.position, new Vector2 (0.9f, 0.9f), 0, Vector2.down, 0.05f, LMDown)) {
			onGround = true;
		} else {
			onGround = false;
		}
	}
	
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.transform == otherPlayer) {
			if (Mathf.Abs(otherPlayer.GetComponent<Rigidbody2D>().velocity.x) < Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)) {
				otherPlayer.Translate (-(transform.position-otherPlayer.position).normalized/10);
				otherPlayer.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
				otherPlayer.GetComponent<Movement>().Speed = Speed;
				Speed = 0;
			}
		}
	}
}
