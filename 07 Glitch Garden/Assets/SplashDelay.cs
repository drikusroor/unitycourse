using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDelay : MonoBehaviour {

	private AudioSource splash;

	// Use this for initialization
	void Start () {
		splash = GetComponent<AudioSource>();
		Invoke ("PlaySplash", 1);
	}

	void PlaySplash() 
	{
		splash.PlayOneShot (splash.clip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
