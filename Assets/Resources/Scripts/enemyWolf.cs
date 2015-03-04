using UnityEngine;
using System.Collections;

public class enemyWolf : MonoBehaviour {
	
	// MOVING
	private Vector3 direction;
	private float speed = 0.03f;

	// LIFE
	private float life = 1;
	private float lifeMax;
	public GameObject lifeBar = null;
	private Vector3 lb = new Vector3(0.1f, 0.03f, 0.004f);

	// COLLISION
	private Vector3 tempA = new Vector3(0, 0, 0);
	private Vector3 tempB = new Vector3(0, 0, 0);

	void Start () {
		randomDirection();
	}
	
	void FixedUpdate () {
		this.transform.Translate(direction);
	}
	
	void OnTriggerEnter(Collider x) {
		tempA = this.transform.position;
		tempA.y = 0;
		if (x.name != "FenceCollider") {
			if (x.name == "Weapon") {
				if (life == 1) {
					lifeBar.renderer.enabled = true;
				} else if (life < 0) {
					this.transform.Translate(new Vector3(0, -200f, 0));
					Destroy(this);
				}
				life -= 0.1f;
				lb.x = life / 10;
				lifeBar.transform.localScale = lb;
				speed = 0.06f;
			} else {
				speed = 0.03f;
			}

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
		direction *= speed;
	}


	void randomDirection () {
		direction = new Vector3(Random.Range(-1.000f, 1.000f), 0, Random.Range(-1.000f, 1.000f));
		direction.Normalize();
		direction *= speed;
	}
}
