using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 ballSpeed = new Vector2 (3f, 10f);

    private Paddle paddle;

    private Vector3 paddleToBallVector;

    private bool gameStarted = false;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        paddle = GameObject.FindObjectOfType<Paddle>();

        paddleToBallVector = this.transform.position - paddle.transform.position;

        // get audio source of game component
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStarted)
        {
            // Lock ball to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse press to start game
            if (Input.GetMouseButtonDown(0))
            {
				this.rigidbody2D.velocity = ballSpeed;
                gameStarted = true;
            }
        }        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		Vector2 tweak = new Vector2 (Random.Range (-0.4f, 0.3f), Random.Range (-0.4f, 0.4f));

		gameObject.rigidbody2D.velocity += tweak;

		if (gameStarted) 
		{
			audioSource.PlayOneShot (audioSource.clip);
		}
    }
}
