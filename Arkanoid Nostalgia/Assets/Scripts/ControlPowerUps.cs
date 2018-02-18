using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUps : MonoBehaviour {

    public Sprite[] powerUpSrpite;

    private Score score;
    private LifeManager life;

    //Tag name for collision
    private string paddleTag = "Paddle";

    // Use this for initialization
    void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
        this.GetComponent<SpriteRenderer>().sprite = powerUpSrpite[8];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == paddleTag)
        {
            Debug.Log("Power Up yeeeeeeeessss");
            life.ContolLives(1);
            score.HitBrickScore(200);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    
}


