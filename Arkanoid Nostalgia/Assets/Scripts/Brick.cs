using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    //How many times can be hit
    public int maxHits ;

    private LevelManager levelmanager;

    //How many times have been hit
    public int timesHit;

	// Use this for initialization
	void Start () {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        SimulateWin();
    }

    //TODO Remove this method when we can actually win
    private void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }

}
