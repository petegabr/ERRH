using UnityEngine;
using System.Collections;

public class exitMain : MonoBehaviour {

	public _MAIN main;

	void Start () {
		Screen.showCursor = false;
		main = this.GetComponent<_MAIN> ();
		main.quitGame(1.5f);
	}

}
