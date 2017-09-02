using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text text;
	private int score = 0;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Score(int scoreAdd) 
	{
		Debug.Log ("Stuff is happenang");
		score += scoreAdd;
		text.text = score.ToString ();
	}

	public void Reset()
	{
		score = 0;
		text.text = score.ToString ();
	}


}
