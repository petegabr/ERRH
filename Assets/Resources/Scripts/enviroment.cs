using UnityEngine;
using System.Collections;
using System.IO;

public class enviroment : MonoBehaviour {

	// FLOOR
	private int differentMaterials = 1;//4;
	private Material[] floorMaterial = null;

	private GameObject[] floor = null;
	public int floorDimension = 10; // it should be prime number - rows and columns of tiles
	public float floorTileDimension = 10; // width and length of floor tile

	// TREES
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

	// SKY
	private GameObject sky = null;
	private float clouds = 100;

	void Start () {
		Screen.lockCursor = true;
		floorSetup();
		PlayerSetup();
		plantTrees();
		fenceSetup();
		skySetup();
	}
	
	void Update () {
		lookingAt = Camera.main.transform.position;
		lookingAt.y = 0f;
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

	// TREES

	Vector3 randomScale (float minScale, float maxScale) {
		float scaleFactor = Random.Range(minScale, maxScale);
		return new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}

	void plantTrees () {
		trees = new GameObject[treeCount];
		for (int i = 0; i < treeCount; i++) {
			trees[i] = Instantiate(Resources.Load(randomTreePath())) as GameObject;
			trees[i].transform.position = randomTreePosition();
			trees[i].transform.localScale = randomScale (minTreeSize, maxTreeSize);
		}
	}

	string randomTreePath () {
		int treeNumber = Random.Range(1, differentTrees + 1);
		return "Prefabs/Tree" + treeNumber.ToString();
	}

	Vector3 randomTreePosition() {
		float d = (floorDimension - 0.5f) * floorTileDimension / 2;
		return new Vector3(Random.Range(-d, d), 0, Random.Range(-d, d));
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

	// SKY

	void skySetup() {
		//sky = new GameObject();
		sky = Instantiate(Resources.Load("Prefabs/Sky")) as GameObject;

		for (int i = 0; i < clouds; i++) {
			GameObject cloud = Instantiate(Resources.Load("Prefabs/Cloud")) as GameObject;
			cloud.transform.SetParent(sky.transform);
			cloud.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
			cloud.transform.Translate(new Vector3(0,
			                                      - floorDimension * floorTileDimension * Random.Range(1, 2),
			                                      Random.Range(-100, -5)));
		}

	}

}








