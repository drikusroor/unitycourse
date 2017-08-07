using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HandleControl ();	
	}

	void HandleControl() {
		Vector3 pos = transform.position;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3 (pos.x - moveSpeed, pos.y);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3 (pos.x + moveSpeed, pos.y);
		}

	}
}
