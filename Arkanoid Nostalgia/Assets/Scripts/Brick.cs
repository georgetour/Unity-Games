using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;

    //Totalbricks that we will access in levelmanager
    public static int totalBricks=0;

    private LevelManager levelmanager;

    //How many times have been hit
    private int timesHit;

    bool isBreakable;


    // Use this for initialization
    void Start () {

        //Set our bricks that have tag Breakable to isBreakable
        isBreakable = (tag == "Breakable");

        //Count all bricks that are breakables
        if (isBreakable)
        {
            totalBricks++;
        }
        
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Handle hits only if you can break it
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;

        //How many times it can be hit
        int maxHits = hitSprites.Length + 1;
        
        //Destroy brick on maxhits and remove the total counter for bricks
        if (timesHit >= maxHits)
        {
            totalBricks--;
            levelmanager.AllBricksDestroyed();
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
        if(hitSprites[spriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    //TODO Remove this method when we can actually win
    private void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }

}
