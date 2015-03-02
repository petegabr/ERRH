using UnityEngine;
using System.Collections;

public class enemiesLevel1 : MonoBehaviour {

	private GameObject[] enemies = null;
	private int enemiesCount = 33;

	private float floorDimension;
	private float floorTileDimension;

	private Vector3 lookingAt;

	// Use this for initialization
	void Start () {
		enemiesSetup();
	}
	
	// Update is called once per frame
	void Update () {
		lookingAt = Camera.main.transform.position;
		lookingAt.y = 0.0f;
		foreach (GameObject wolf in enemies) {
			wolf.transform.GetChild(0).transform.LookAt(lookingAt);
		}

	}

	// ENEMIES SETUP
	void enemiesSetup() {
		floorDimension = this.GetComponent<enviroment>().floorDimension;
		floorTileDimension = this.GetComponent<enviroment>().floorTileDimension;

		enemies = new GameObject[enemiesCount];
		for (int i = 0; i < enemiesCount; i++) {
			enemies[i] = Instantiate(Resources.Load("Prefabs/Wolf")) as GameObject;
			enemies[i].transform.Translate(randomPosition());
		}
	}

	Vector3 randomPosition() {
		return new Vector3(Random.Range(- (floorDimension - 1) * floorTileDimension / 2, floorDimension * floorTileDimension / 2),
		                   0,
		                   Random.Range(- (floorDimension - 1) * floorTileDimension / 2, floorDimension * floorTileDimension / 2));
	}
}





