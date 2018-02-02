using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy me on load! " + name);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeVolume(float volume)
    {
        Debug.Log(volume);
        audioSource.volume = volume;
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip for level " + thisLevelMusic);

        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
