using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	private Vector3 originalScale;
	private float currentScaleX;

	// power up props
	private int maxResizeScale = 3;

	// Use this for initialization
	void Start () {
		originalScale = transform.localScale;
		currentScaleX = transform.localScale.x;
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
    }

	void AutoPlay() {
		float ballPos = Mathf.Clamp( ball.transform.position.x , 0.5f * currentScaleX, 16f - 0.5f * currentScaleX) ;
		Vector3 currentPos = this.transform.position;
		Vector3 newPos = new Vector3(ballPos, currentPos.y, currentPos.z);
		
		this.transform.position = newPos;
	}

	void MoveWithMouse()
	{
		float mousePosInBlocks = Mathf.Clamp( Input.mousePosition.x / Screen.width * 16 , 0.5f * currentScaleX, 16f - 0.5f * currentScaleX) ;
		Vector3 currentPos = this.transform.position;
		Vector3 newPos = new Vector3(mousePosInBlocks, currentPos.y, currentPos.z);
		
		this.transform.position = newPos;
	}

	void WidePaddle() {
		if (currentScaleX / maxResizeScale < originalScale.x) {
			transform.localScale = new Vector3 (transform.localScale.x * 2, transform.localScale.y, transform.localScale.z);
		}
		currentScaleX = transform.localScale.x;
	}

	void SlimPaddle() {
		float currentScaleX = transform.localScale.x;
		if (currentScaleX * maxResizeScale > originalScale.x) {
			transform.localScale = new Vector3 (transform.localScale.x / 2, transform.localScale.y, transform.localScale.z);
		}
		currentScaleX = transform.localScale.x;
	}

	public void ActivatePowerUp(string powerUpName) {

		if (powerUpName == "WidePaddle") {
			WidePaddle ();
		} else if (powerUpName == "SlimPaddle") {
			SlimPaddle();
		}

	}

}
