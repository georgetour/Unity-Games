using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : ControlPowerUps {

    public int scoreToGive;

    public override void PowerUpBehavior()
    {
        SmokePuffs();
        life.ContolLives(1);
        score.HitBrickScore(scoreToGive);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == paddleTag)
        {  
            PowerUpBehavior();
            
        }
    }


}
