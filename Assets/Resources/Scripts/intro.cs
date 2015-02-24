using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {

	float delay = 10.0f;
	public _MAIN main;

	void Start () {
		Screen.showCursor = false;
		main = this.GetComponent<_MAIN> ();
		main.loadLevel(main.MainMenu, delay);
	}
	
}
