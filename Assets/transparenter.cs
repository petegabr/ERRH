using UnityEngine;
using System.Collections;

public class transparenter : MonoBehaviour {

	Color color;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		/*color = c.renderer.material.color;
		color.a = 0.5f;
		c.renderer.material.color = color;*/
	}


}
