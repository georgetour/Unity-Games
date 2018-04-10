using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFireball : ControlPowerUps {

    public static bool fireball = false;
    public int scoreToGive;

    public override void PowerUpBehavior(Collider2D collision)
    {

        
        if (collision.transform.tag == paddleTag)
        {
            SmokePuffs();
            score.HitBrickScore(scoreToGive);
            fireball = true;
            
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        PowerUpBehavior(collision);
    }

    
}
