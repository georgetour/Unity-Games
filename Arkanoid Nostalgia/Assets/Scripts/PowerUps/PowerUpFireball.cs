using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFireball : ControlPowerUps {

    public static bool fireball;
    public int scoreToGive;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void PowerUpBehavior(Collider2D collision)
    {
        if (collision.transform.tag == paddleTag)
        {
            SmokePuffs();
            score.HitBrickScore(scoreToGive);
            fireball = true;
        }

        else if (collision.transform.tag == loseTag)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpBehavior(collision);
    }

}
