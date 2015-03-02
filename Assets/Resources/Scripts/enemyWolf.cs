using UnityEngine;
using System.Collections;

public class enemyWolf : MonoBehaviour {
	
	// MOVING
	private Vector3 direction;
	private float speed = 0.03f;
	
	// COLLISION
	private Vector3 tempA = new Vector3(0, 0, 0);
	private Vector3 tempB = new Vector3(0, 0, 0);

	void p(Vector3 foo) {
		Debug.Log("(" + foo.x + ", " + foo.y + ", " + foo.z + ")");
	}

	void Start () {
		randomDirection();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(direction);
	}
	
	void OnTriggerEnter(Collider x) {
		tempA = this.transform.position;
		tempA.y = 0;
		if (x.name != "FenceCollider") {
			if (x.name != "WolfCollider") {
				tempB = x.transform.position;
				tempB.y = 0;
				direction = tempA - tempB;
			} else {
				randomDirection();
			}
		} else {
			direction = -tempA;
		}
		direction.Normalize();
		direction *= 0.03f;
	}


	void randomDirection () {
		direction = new Vector3(Random.Range(-1.000f, 1.000f), 0, Random.Range(-1.000f, 1.000f));
		direction.Normalize();
		direction *= speed;
	}
}
