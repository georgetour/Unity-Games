using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;
    


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
 
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }


    //Play music according to level and our public AudioClip array clip
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        if (thisLevelMusic && audioSource.clip != thisLevelMusic)
        {
            Debug.Log("start music");
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
            
           
        
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
