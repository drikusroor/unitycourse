using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
