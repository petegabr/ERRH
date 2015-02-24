using UnityEngine;
using System.Collections;

public class skipToNext : MonoBehaviour {

	public _MAIN main;

	void Start () {
		main = this.GetComponent<_MAIN>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.anyKeyDown) {
			main.loadLevel(Application.loadedLevel + 1, 0.0f);
		}
	}
}
