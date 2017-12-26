using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip winClip;

	private AudioSource audioSource;

	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			audioSource = GetComponent<AudioSource> ();
			audioSource.clip = startClip;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	void OnLevelWasLoaded(int level)
	{
		Debug.Log ("Level loaded in music player: " + level.ToString());
		audioSource.Stop ();
		if (level == 0) {
			audioSource.clip = startClip;
		} else if (level == 1) {
			audioSource.clip = gameClip;
		} else if (level == 2) {
			audioSource.clip = winClip;
		}
		audioSource.loop = true;
		audioSource.Play ();
	}
}
