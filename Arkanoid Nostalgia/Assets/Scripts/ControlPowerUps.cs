using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlPowerUps : MonoBehaviour {
    //***ALL POWER UPS WILL INHERIT FROM THIS CLASS***
    //What power ups will do
    public abstract void PowerUpBehavior();

    protected Score score;
    protected LifeManager life;
    protected Paddle paddle;
    
    //Tag name for collision
    public string paddleTag = "Paddle";
    public string loseTag = "LoseCollider";


    // Use this for initialization
    void Awake () {

        paddle = GameObject.FindGameObjectWithTag(paddleTag).GetComponent<Paddle>();


        score = GameObject.Find("Score").GetComponent<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
        
    }





    
}


