using UnityEngine;
using System.Collections;

public class sky : MonoBehaviour {

	private Vector3 rotation = new Vector3(0f, -0.02f, 0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Rotate(rotation);
	}
}
