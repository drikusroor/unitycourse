using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashImageDelay : MonoBehaviour {

	private 

	// Use this for initialization
	void Start () {
		transform.gameObject.SetActive (false);
		Invoke ("ShowSplashImage", 1);
	}

	void ShowSplashImage()
	{
		transform.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
