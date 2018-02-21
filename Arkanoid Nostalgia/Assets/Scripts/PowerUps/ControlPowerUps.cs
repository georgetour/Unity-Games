﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ControlPowerUps : MonoBehaviour {
    
    //***ALL POWER UPS WILL INHERIT FROM THIS CLASS***
    //What power ups will do
    public virtual void PowerUpBehavior()
    {
        this.PowerUpBehavior();
    }
    
    public virtual void PowerUpBehavior(Collider2D collision)
    {

        this.PowerUpBehavior(collision);
    }

    protected Score score;
    protected LifeManager life;
    protected Paddle paddle;
    public AudioClip sound;
    public GameObject smoke;

    //Tag name for collision
    public string paddleTag = "Paddle";
    public string loseTag = "LoseCollider";


    // Use this for initialization
    void Awake () {
        paddle = GameObject.FindGameObjectWithTag(paddleTag).GetComponent<Paddle>();
        score = GameObject.Find("Score").GetComponent<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
        
    }

    //Handle the particle when get the power up
    public void SmokePuffs()
    {
        var smokePuff = Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
        //Destroy smokepuff after 2 seconds so you don't get unlimited Smoke clones
        AudioSource.PlayClipAtPoint(sound, transform.position);
        Destroy(smokePuff, 2f);
        Destroy(gameObject);
    }




}


