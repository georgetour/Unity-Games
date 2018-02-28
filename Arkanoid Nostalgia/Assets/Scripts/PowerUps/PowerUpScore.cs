using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScore : ControlPowerUps {

    public int scoreToGive;
    
    public override void PowerUpBehavior()
    {
        SmokePuffs();
        score.HitBrickScore(scoreToGive); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == paddleTag)
        {  
            PowerUpBehavior();
        }
        
    }


}
