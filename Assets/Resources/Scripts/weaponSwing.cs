     using UnityEngine;
using System.Collections;

public class weaponSwing : MonoBehaviour {

	private Animator ani;
	public bool hitting = false;
	public bool stopped = true;
	private Transform kij = null;


	void Start () {
		ani = this.GetComponent<Animator>();
		kij = this.transform.GetChild(1);
	}
	
	void Update () {
		if (Input.GetMouseButton(0) && !hitting){
			ani.SetTrigger("hit");
			hitting = true;
			stopped = false;
			kij.collider.enabled = true;
		}
		if (hitting == false && stopped == false) {
			stopped = true;
			kij.collider.enabled = false;
		}
	}
	
}
