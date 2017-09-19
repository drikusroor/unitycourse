using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("GoToStartScene", 5);
	}

	void GoToStartScene()
	{
		LevelManager levelManager = new LevelManager ();

		levelManager.LoadLevel("Start Menu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
