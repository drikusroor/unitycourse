using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	private int timerInSeconds = 10;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidbody2D;
	private bool hitPaddle;

	private Paddle paddle;

	private string powerUpType;
	private Color goodPowerUp = new Color(0.2f, 0.8f, 0.2f);
	private Color badPowerUp = new Color(0.8f, 0.2f, 0.2f);

	private static int amountOfActivePowerUps = 0;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.AddForce(new Vector2(0f, 2f));

		ChoosePowerUp ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static void ArrangePowerUps() 
	{

	}

	void ChoosePowerUp() 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		int type = Random.Range (0, 5);

		// temporarily it is always the same type
		spriteRenderer.color = goodPowerUp;
		if (type < -1) {
			powerUpType = "WidePaddle";
		} else {
			powerUpType = "SlimPaddle";
		}
	}

	void HandleHit() {

		rigidbody2D.isKinematic = true;
		transform.position = new Vector3 (1f, 1f, 0f);

		// Activate 
		paddle.ActivatePowerUp (powerUpType);

	}

	void OnTriggerEnter2D(Collider2D other) {

		print (other.gameObject.tag);

		if (other.gameObject.tag == "Paddle") {
			hitPaddle = true;

			HandleHit();

		} else {
			if (other.gameObject.tag == "LoseCollider") {
				GameObject.Destroy(gameObject);
			}
		}
	}
}
