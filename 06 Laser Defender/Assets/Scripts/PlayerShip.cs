using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

	public GameObject laser;
	public float laserSpeed;
	public float moveSpeed;
	public float padding = 1f;
	float xmin = -5f;
	float xmax = 5f;

	// Use this for initialization
	void Start () {
		SetPlayerBoundaries ();
	}

	void SetPlayerBoundaries()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		HandleControl ();	
		HandleShoot ();
	}

	void HandleShoot() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject laserObject = Instantiate (laser, transform.position, Quaternion.identity) as GameObject;
			laserObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, laserSpeed); 
		}
	}

	void HandleControl() {
		Vector3 pos = transform.position;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}

		// Restrict player to game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

	}
}
