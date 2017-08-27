using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float health = 300f;

	public GameObject laser;
    public GameObject shootSmoke;
    public float laserSpeed;
	public float firingRate;

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

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", .001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void Fire() {
        Vector3 startPosition = transform.position + new Vector3(0f, 1f, 0f);
        GameObject laserObject = Instantiate(laser, startPosition, Quaternion.identity) as GameObject;
        laserObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, laserSpeed);

        Vector3 smokePosition = transform.position + new Vector3(0f, 0f, 5f);
        GameObject shootSmokeObject = Instantiate(shootSmoke, smokePosition, Quaternion.Euler(90, 0, 0)) as GameObject;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
            print("Hit by projectile!");
            print("Projectile damage: " + projectile.GetDamage().ToString());
            print("Health: " + health);
        }
        else
        {
            print("Hit by something other!");
        }
    }

}
