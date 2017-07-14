using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
