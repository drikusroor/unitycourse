using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("GoToStartScene", 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoToStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}
