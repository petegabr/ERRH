using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public _MAIN main;

	void Start () {
		Screen.showCursor = true;
		main = this.GetComponent<_MAIN>();
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Escape)) {
			Go(main.Exit); // exit
		}
	}

	public void Go (int level) {
		main.loadLevel(level, 0.0f);
	}
	
}
