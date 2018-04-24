using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        
        //Get volume and difficulty from playerPrefs that we have saved
        volumeSlider.value = PlayerPrefsManager.GetVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}


    //Save changes and go back to the start
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("Start");
    }

    //Set everything to default
    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }

    //Change music volume dynamically
    private void Update()
    {
        musicManager.ChangeVolume(volumeSlider.value);
    }




}
