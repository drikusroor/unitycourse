using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    
    public float delay;
    public float duration;
    public float direction;
    public Color fadeFrom;
    public bool disableAfterFade = false;

    private Image img;
    private bool startFade = false;


	// Use this for initialization
	void Start () {
        Invoke("StartFade", delay);
        img = gameObject.GetComponent<Image>();
        img.color = fadeFrom;
    }

    void StartFade()
    {
        Debug.Log("Start fade wordt true!");
        startFade = true;
    }

	// Update is called once per frame
	void Update () {
        if (startFade == true)
        {
            Debug.Log("Start fade is true!");
            if (Time.timeSinceLevelLoad - delay < duration)
            {
                // Fade in
                float alphaChange = Time.deltaTime / duration;
                fadeFrom.a += alphaChange * direction;
                img.color = fadeFrom;
            } else if (disableAfterFade == true)
            {
                gameObject.SetActive(false);
            }
        }
	}
}
