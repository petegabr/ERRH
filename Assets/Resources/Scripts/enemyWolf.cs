using UnityEngine;
using System.Collections;

public class enemyWolf : MonoBehaviour {
	
	// MOVING
	private Vector3 direction = new Vector3(0, 0, 0);
	private float speed = 0.03f;
	
	// COLLISION
	private Vector3 tempA = new Vector3(0, 0, 0);
	private Vector3 tempB = new Vector3(0, 0, 0);
	//private bool changeDirection = false;
	//private Vector3 moveTowards = new Vector3(0, 0, 0);
	
	void Start () {
		direction.x = Random.Range(-1, 1);
		direction.z = Random.Range(-1, 1);
		direction.Normalize();
		direction *= speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(direction);
	}
	
	void OnTriggerEnter(Collider x) {
		//Debug.Log(x.name);
		//changeDirection = true;
		tempA = this.transform.position;
		tempA.y = 0;
		if (x.name != "FenceCollider") {
			tempB = x.transform.position;
			tempB.y = 0;
			direction = tempA - tempB;
		} else {
			//tempB.x = 0;
			//tempB.y = 0;
			//tempB.z = 0;
			direction = -tempA;
		}
		direction.Normalize();
		direction *= speed;
	}
	
}
