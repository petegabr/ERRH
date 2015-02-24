using UnityEngine;
using System.Collections;

public class enviroment : MonoBehaviour {

	// FLOOR
	private int materialCount = 4;
	private Material[] floorMaterial = null;

	private GameObject[] floor = null;
	private int floorDimension = 10; // it should be prime number

	// LIGHT
	private GameObject globalLight = null;

	// TREES
	// ...

	// FENCE
	// ...

	// PLAYER
	// ...
	
	// ENEMIES
	// ...

	void Start () {
		floorSetup();
		lightSetup();
	}
	
	void Update () { // I THINK, WE WILL NOT NEED THIS FUNCTION
	
	}

	// FLOOR

	void LoadFloorMaterials() {
		floorMaterial = new Material[materialCount];
		string materialPath;
		for (int i = 1; i <= materialCount; i++) {
			materialPath = "Materials/Tla" + i.ToString();
			floorMaterial[i - 1] = Instantiate(Resources.Load(materialPath)) as Material;
		}
	}

	Material randomFloorMaterial () {
		return floorMaterial[Random.Range(0, materialCount)];
	}

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
				floorPosition.x = i * 10;
				floorPosition.z = j * 10;
				floor[stevec] = Instantiate(Resources.Load("Prefabs/FloorPlane"), floorPosition, Quaternion.identity) as GameObject;
				floor[stevec].renderer.material = randomFloorMaterial();
				floor[stevec].renderer.transform.Rotate(new Vector3(0, Random.Range(0, 3) * 90, 0));
				stevec++;
			}
		}
	}

	// LIGHT

	void lightSetup () {
		globalLight = new GameObject("lightyLight");
		globalLight.AddComponent<Light>();
		globalLight.light.type = LightType.Directional;
		globalLight.light.transform.Rotate(new Vector3(90, 0, 0));
		globalLight.light.intensity = 0.2f;
	}

	// TREES

}








