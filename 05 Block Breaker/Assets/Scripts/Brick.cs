using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] brickSprites;

    private int timesHit = 0;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
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
            Destroy(gameObject);
        }
        else
        {
            nextSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            HandleHits();
        }        
    }
}
