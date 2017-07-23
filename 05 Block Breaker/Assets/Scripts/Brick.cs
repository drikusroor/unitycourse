using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] brickSprites;
    public static int breakableCount = 0;
	public AudioClip collisionSound;

    private int timesHit = 0;
    private SpriteRenderer spriteRenderer;
    private bool isBreakable;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");

		print (isBreakable.ToString ());

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

    void HandleHits()
    {
        timesHit++;
        int maxHits = brickSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
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
		AudioSource.PlayClipAtPoint (collisionSound, transform.position);
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
