using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
