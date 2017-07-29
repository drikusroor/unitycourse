using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] brickSprites;
    public static int breakableCount = 0;
	public AudioClip collisionSound;
	public GameObject powerUpPrefab;
	public GameObject smoke;

    private int timesHit = 0;
    private SpriteRenderer spriteRenderer;
    private bool isBreakable;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void nextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (brickSprites[spriteIndex])
        {
            spriteRenderer.sprite = brickSprites[spriteIndex];
        }
    }

	void powerUpSpawn() {
		int chance = Random.Range (0, 2);
		if (chance == 0) {
			GameObject.Instantiate(powerUpPrefab, transform.position, transform.rotation);
		}
	}

    void HandleHits()
    {
        timesHit++;
        int maxHits = brickSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();

			powerUpSpawn();
			smoke.GetComponent<ParticleSystem>().startColor = spriteRenderer.color;
			Instantiate(smoke, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        else
        {
			print ("next sprite?");
            nextSprite();
        }
    }

	void HandleCollisionSound() 
	{
		float volume = 1f;
		// our ping sound is a little loud so we decrease its volume here
		if (!isBreakable)
			volume = 0.4f;
		AudioSource.PlayClipAtPoint (collisionSound, transform.position, volume);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		HandleCollisionSound ();

        if (isBreakable)
        {
            HandleHits();
        }
    }
}
