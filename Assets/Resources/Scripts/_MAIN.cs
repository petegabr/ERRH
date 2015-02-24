using UnityEngine;
using System.Collections;

public class _MAIN : MonoBehaviour {

	public int Splash = 0;
	public int Intro = 1;
	public int MainMenu = 2;
	public int Options = 4;
	public int Exit = 3;

	// LEVELS
	public int Level1 = 5;
	public int Story1 = 6;

	private Texture2D textureBlack;
	private float fadeSpeed = 2.0f;
	float fadeTime;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	
	void Start () {
		textureBlack = Instantiate(Resources.Load("Textures/black")) as Texture2D;
	}

	void OnGUI() {
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textureBlack);
	}

	// FADING

	public float BeginFade (int direction) {
		fadeDir = direction;
		return 1 / fadeSpeed;
	}
	
	void OnLevelWasLoaded() {
		BeginFade(-1);
	}

	public void loadLevel(int level, float delay) {
		StartCoroutine(loadLevelCo(level, delay));
	}

	private IEnumerator loadLevelCo(int level, float delay) {
		yield return new WaitForSeconds(delay);
		fadeTime = BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(level);
	}

	// QUIT GAME

	public void quitGame (float delay) {
		StartCoroutine(quitGameCo(delay));
	}

	private IEnumerator quitGameCo(float delay) {
		yield return new WaitForSeconds(delay);
		fadeTime = BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.Quit();
	}
}







