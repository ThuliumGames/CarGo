using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	
	public bool isBullet;
	
	public Transform ObjectToShoot;
	
	public GameObject Bullet;
	public int ShootDelay = 60;
	public int MoveSpeed = 10;
	
	void Update () {
		
		if (!isBullet) {
			Vector3 Num = ObjectToShoot.position - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, Mathf.Atan2(Num.x, -Num.y)*Mathf.Rad2Deg), MoveSpeed*Time.deltaTime);
			
			if (Time.frameCount%ShootDelay == 0) {
				GameObject G = Instantiate (Bullet, transform.position, transform.rotation);
			}
		} else {
			transform.Translate (0, -MoveSpeed*Time.deltaTime, 0);
			if (!this.GetComponent<Renderer>().isVisible) {
				Kill();
			}
			
		}
	}
	
	void Kill () {
		Destroy (this.gameObject);
	}
}
