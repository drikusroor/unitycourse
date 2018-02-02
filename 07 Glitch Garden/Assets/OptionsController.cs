using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public LevelManager levelManager;
    public Slider difficultySlider;
    public Slider volumeSlider;

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	} 
	
	// Update is called once per frame
	void Update () {
        Debug.Log(volumeSlider);
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SetDefaults()
    {
        difficultySlider.value = 2f;
        volumeSlider.value = .5f;
    }

    public void SaveAndExit ()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01a Start");
    }
}
