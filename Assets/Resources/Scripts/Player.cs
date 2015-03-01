using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// MOVEMENT
	private Vector3 rotation;
	private float speedx = 0.0f;
	private float speedz = 0.0f;
	private float acceleration = 0.03f;
	private float deceleration = 0.06f;
	private Vector3 speedDirection;
	private float speedMagnitude = 0.07f;

	// CAMERA LOOK
	private float mousePosition = 0;
	private float mouseSensitivity = 3f;

	// Use this for initialization
	void Start () {
		rotation = new Vector3(0, 0, 0);

		//mousePositionOld = Input.mousePosition;

		mousePosition = Input.GetAxis("Mouse X");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// forward and backward
		if (Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)) {
			speedz = smooth(speedz, 1.0f, acceleration);
		} else if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.W)) {
			speedz = smooth(speedz, -1.0f, acceleration);
		} else {
			speedz = smooth(speedz, 0.0f, deceleration);
		}

		// moving left and right
		if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			speedx = smooth(speedx, 1.0f, acceleration);
		} else if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			speedx = smooth(speedx, -1.0f, acceleration);
		} else {
			speedx = smooth(speedx, 0.0f, deceleration);
		}

		mousePosition = Input.GetAxis("Mouse X");
		rotation.y = mousePosition * mouseSensitivity;
		this.transform.Rotate(rotation);

		//this.transform.position = position;


		speedDirection.x = speedx;
		speedDirection.y = 0;
		speedDirection.z = speedz;
		speedDirection.Normalize();

		this.transform.Translate(speedDirection * speedMagnitude * Mathf.Min(1.0f, Mathf.Abs(speedx) + Mathf.Abs(speedz)) );
	}

	private float smooth(float currentValue, float finalValue, float step) { // actually acceleration
		step = Mathf.Abs(step);
		if (currentValue < finalValue) {
			currentValue += step;
			if (currentValue > finalValue) {
				currentValue = finalValue;
			}
		} else {
			currentValue -= step;
			if (currentValue < finalValue) {
				currentValue = finalValue;
			}
		}
		return currentValue;
	}
}
