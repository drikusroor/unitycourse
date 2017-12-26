using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> 9ceb6e49ea7f113b2495a4edc568962bc560f137

public class GoToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        Invoke("GoToStartScene", 3);
    }
=======
		Invoke ("GoToStartScene", 5);
	}

	void GoToStartScene()
	{
		LevelManager levelManager = new LevelManager ();

		levelManager.LoadLevel("Start Menu");
	}
>>>>>>> 9ceb6e49ea7f113b2495a4edc568962bc560f137
	
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD

    void GoToStartScene()
    {
        SceneManager.LoadScene("Start");
    }
=======
>>>>>>> 9ceb6e49ea7f113b2495a4edc568962bc560f137
}
