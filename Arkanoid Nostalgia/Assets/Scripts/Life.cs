using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public List<Sprite> lifeSprites;

    private int lives = 3;
    

	// Use this for initialization
	void Start () {
        Debug.Log(lives);
        TotalLives();
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TotalLives()
    {
        int livesIndex = lives;

        if (lifeSprites[livesIndex]!=null)
        {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesIndex];
        }
        Debug.Log(lifeSprites[livesIndex]);

    }
}
