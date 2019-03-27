using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	
	public int Player;
	public Animator Anim;
	public float moveSpeed;
	
	public Rigidbody RB;
	
	Vector3 Rot;
	
	bool CanJump;
	
	void Update () {
		
		if (new Vector2(SSInput.LHor[Player], SSInput.LVert[Player]).magnitude > 0.01f && !RB.isKinematic) {
			transform.eulerAngles = new Vector3 (0, (Mathf.Atan2 (SSInput.LHor[Player], SSInput.LVert[Player])*Mathf.Rad2Deg)+Camera.main.transform.eulerAngles.y, 0);
		}
		Vector3 Vel = (transform.forward * (new Vector2(SSInput.LHor[Player], SSInput.LVert[Player]).magnitude * moveSpeed)) * Time.deltaTime;
		RaycastHit H;
		if (Physics.Raycast (transform.position, Vector3.down, out H, 1.5f)) {
			CanJump = true;
			transform.position = new Vector3 (transform.position.x, H.point.y+1f, transform.position.z);
			RB.velocity = Vel;
		} else {
			Anim.Play("Idle");
			RB.velocity = new Vector3 (Vel.x/2, RB.velocity.y, Vel.z/2);
		}
		if (SSInput.X[Player] == "Pressed" && CanJump) {
			CanJump = false;
			transform.Translate (0, 0.6f, 0);
			RB.velocity = new Vector3 (RB.velocity.x, 7, RB.velocity.z);
		}
	}
}
