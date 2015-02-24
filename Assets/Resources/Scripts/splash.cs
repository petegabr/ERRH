using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {

	float delay = 3.0f;
	public _MAIN main;

	void Start () {
		Screen.showCursor = false;
		main = this.GetComponent<_MAIN>();
		main.loadLevel(main.Intro, delay);

	}

}
