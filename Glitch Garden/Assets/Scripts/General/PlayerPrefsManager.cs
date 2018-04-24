using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{


    //Constants for general use everywhere we want as PlayerPrefs
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";


    //Set master volume to PlayerPrefs
    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }

    }

    //Get master volume from PlayerPrefs
    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);

    }


    //Unlock level and save ti to player prefs hust for testing. 1 represents true so level is unlocked
    //Example level_unlocked_01
    public static void UnlockLevel (int level)
    {
        if (level <= SceneManager.sceneCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Not in build order");
        }
    }


    //Get if level isUnlocked
    public static bool isLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());

        //Checks if it s true or false
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }

       
    }

    //Set difficulty
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty > 0 && difficulty<= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }



    //Get difficulty
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);

    }





}


