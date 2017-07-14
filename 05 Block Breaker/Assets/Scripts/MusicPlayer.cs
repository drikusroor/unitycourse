using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static int musicPlayerCount = 0;

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
        if (MusicPlayer.musicPlayerCount > 0)
        {
            GameObject.Destroy(gameObject);
        }
        MusicPlayer.musicPlayerCount += 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
