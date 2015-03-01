using UnityEngine;
using System.Collections;

public class sky : MonoBehaviour {

	private Vector3 rotation = new Vector3(0f, -0.02f, 0f);

	void Update () {
		this.transform.Rotate(rotation);
	}
}
