using UnityEngine;
using System.Collections;

public class escapeToMainMenu : MonoBehaviour {

	bool exitingLevel = false;
	public _MAIN main;

	void Start () {
		main = this.GetComponent<_MAIN> ();
	}

	void FixedUpdate () {
		if (!exitingLevel && Input.GetKey(KeyCode.Escape)) {
			exitingLevel = true;
			main.loadLevel(2, 0.0f);
		}
	}
}
