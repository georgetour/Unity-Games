using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    //How many times can be hit
    public int maxHits ;
    public Sprite[] hitSprites;


    private LevelManager levelmanager;

    //How many times have been hit
    private int timesHit;

	// Use this for initialization
	void Start () {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        timesHit++;
        //Destroy brick on maxhits
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        //Find Array indexer according to times hit so if hit one time the array ndexer will be 0
        int spriteIndex = timesHit - 1;

        //Find component sprite renderer and change it according to index
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    //TODO Remove this method when we can actually win
    private void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }

}
