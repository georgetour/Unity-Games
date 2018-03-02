using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : ControlPowerUps {

    public override void PowerUpBehavior()
    {
        SmokePuffs();
        life.ContolLives(1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == paddleTag)
        {  
            PowerUpBehavior();
            
        }
    }


}
