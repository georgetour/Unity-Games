using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public List<Sprite> lifeSprites;

    public static int lives = 3;
    

	// Use this for initialization
	void Start () {

        if (lifeSprites[lives] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[lives];
        }

    }
	
    //Reset lives for starting game
    public static void ResetLives()
    {
        
        lives = 3;
    }

   
    //Gain or remove lives according to parameter
    public void ContolLives(int gainLoseLife)
    {
        
        lives += gainLoseLife;
        
        //Limit Lives
        if(lives >= 5)
        {
            lives = 5;
        }
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[lives];
        
    }
}
