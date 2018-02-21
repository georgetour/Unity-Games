using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer instance = null;

     void Awake()
     {
        ////If any Music Player exists destroy it else continue in next scenes
        if (instance != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
            //GameObject.DontDestroyOnLoad(gameObject);
        }
    }
  
   

    

}
