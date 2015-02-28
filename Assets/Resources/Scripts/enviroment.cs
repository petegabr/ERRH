using UnityEngine;
using System.Collections;
//using System;
using System.IO;

public class enviroment : MonoBehaviour {

	// FLOOR
	private int differentMaterials = 1;//4;
	private Material[] floorMaterial = null;

	private GameObject[] floor = null;
	public int floorDimension = 10; // it should be prime number - rows and columns of tiles
	public float floorTileDimension = 10; // width and length of floor tile

	// LIGHT !!!!!!! LIGHT WILL BE ATTACHED TO PLAYER!! TWO LIGHTS ACTUALLY
	private GameObject globalLight1 = null;
	private GameObject globalLight2 = null;

	// TREES
	// trees should not be in random positions ...
	private float[][] treeCoordinates;
	private GameObject[] trees = null;
	private int differentTrees = 3;
	private int treeCount = 200;
	float minTreeSize = 0.5f;
	float maxTreeSize = 1.5f;

	// FENCE
	private GameObject[] fences = null;

	// PLAYER
	private GameObject player = null;
	private Vector3 lookingAt;
	
	// ENEMIES
	// ...
	// I think, enemies should have their own script

	void Start () {
		Screen.lockCursor = true;
		floorSetup();
		lightSetup();
		PlayerSetup();
		plantTrees();
		fenceSetup();
	}
	
	void Update () {
		lookingAt = Camera.main.transform.position;
		lookingAt.y = 0.1f;
		foreach (GameObject tree in trees) {
			tree.transform.LookAt(lookingAt);
		}
	}

	// FLOOR

	void floorSetup () {
		LoadFloorMaterials();
		if (floorDimension % 2 == 1) {
			floorDimension += 1;
		}
		floor = new GameObject[floorDimension * floorDimension];
		int stevec = 0;
		Vector3 floorPosition = new Vector3(0, 0, 0);
		for (int i = -floorDimension / 2; i < floorDimension / 2; i++) {
			for (int j = -floorDimension / 2; j < floorDimension / 2; j++) {
				floorPosition.x = i * floorTileDimension + floorTileDimension / 2;
				floorPosition.z = j * floorTileDimension + floorTileDimension / 2;
				floor[stevec] = Instantiate(Resources.Load("Prefabs/FloorPlane"), floorPosition, Quaternion.identity) as GameObject;
				floor[stevec].renderer.material = randomFloorMaterial();
				//floor[stevec].renderer.transform.Rotate(new Vector3(0, Random.Range(0, 3) * 90, 0));
				stevec++;
			}
		}
	}
	
	void LoadFloorMaterials() {
		floorMaterial = new Material[differentMaterials];
		string materialPath;
		for (int i = 1; i <= differentMaterials; i++) {
			materialPath = "Materials/Floor" + i.ToString();
			floorMaterial[i - 1] = Instantiate(Resources.Load(materialPath)) as Material;
		}
	}

	Material randomFloorMaterial () {
		return floorMaterial[Random.Range(0, differentMaterials)];
	}

	// LIGHT

	void lightSetup () {
		globalLight1 = new GameObject("lightyLight1");
		globalLight1.AddComponent<Light>();
		globalLight1.light.type = LightType.Directional;
		globalLight1.light.transform.Rotate(new Vector3(0, 0, 0));
		globalLight1.light.intensity = 0.2f;

		globalLight2 = new GameObject("lightyLight2");
		globalLight2.AddComponent<Light>();
		globalLight2.light.type = LightType.Directional;
		globalLight2.light.transform.Rotate(new Vector3(90, 0, 0));
		globalLight2.light.intensity = 0.2f;
	}

	// TREES

	Vector3 randomScale (float minScale, float maxScale) {
		float scaleFactor = Random.Range(minScale, maxScale);
		return new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}

	private bool insertTreeCoordinate (float x, float y, int d) {
		if (d == 0) {
			treeCoordinates[d][0] = x;
			treeCoordinates[d][1] = y;
			return true;
		}
		for (int i = 0; i < d; i++) {
			if (x == treeCoordinates[i][0] && y == treeCoordinates[i][1]) {
				return false;
			}
		}
		treeCoordinates[d][0] = x;
		treeCoordinates[d][1] = y;
		return true;
	}

	float mreza (float value) {
		float foo = 2;
		value = value * foo;
		value = Mathf.Round(value);
		value = value / foo;
		return value;
	}

	void plantTrees () {
		treeCoordinates = new float[treeCount][];
		float x = 0;
		float y = 0;
		float m = (floorDimension - 1) * floorTileDimension / 2;
		trees = new GameObject[treeCount];
		for (int i = 0; i < treeCount; i++) {
			treeCoordinates [i] = new float[2];

			x = mreza (Random.Range (-m, m));
			y = mreza (Random.Range (-m, m));
			while (!insertTreeCoordinate(x, y, i)) {
				x = mreza (Random.Range (-m, m));
				y = mreza (Random.Range (-m, m));
			}

			trees [i] = Instantiate (Resources.Load (randomTreePath ())) as GameObject;
			trees [i].transform.position = treePosition (x, y);
			trees [i].transform.localScale = randomScale (minTreeSize, maxTreeSize);
		}
	}

	string randomTreePath () {
		int treeNumber = Random.Range(1, differentTrees + 1);
		return "Prefabs/Tree" + treeNumber.ToString();
	}

	Vector3 treePosition(float x, float z) {
		return new Vector3(x, 0, z);
	}

	// FENCE // !!! -- spremeni tako, da se bo dalo polje raztegovati, ograje pa se bojo primerno podaljšale!!
	void fenceSetup() {
		fences = new GameObject[4];
		for (int i = 0; i < 4; i++) {
			fences[i] = Instantiate(Resources.Load("Prefabs/Fence")) as GameObject;
			fences[i].transform.Rotate(new Vector3(0f, i * 90f, 0f));
			fences[i].transform.Translate(new Vector3(0f, 0f, floorDimension * floorTileDimension / 2));
		}
	}
	
	// PLAYER

	void PlayerSetup () {
		player = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
		player.transform.SetParent(this.transform);
		lookingAt = new Vector3(0, 0, 0);
	}
	
	// ENEMIES
	// ...

}








