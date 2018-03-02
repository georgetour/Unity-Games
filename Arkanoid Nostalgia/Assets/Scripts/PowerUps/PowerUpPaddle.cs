using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : ControlPowerUps {

    public string powerUp;

	public override void PowerUpBehavior(Collider2D collider)
    {
        

        if (collider.transform.tag == paddleTag &&  powerUp == "big")
        {
            SmokePuffs();
            paddle.transform.localScale = new Vector3(0.8f, 0.6781099f, 1); 
        }
        else if (collider.transform.tag == paddleTag && powerUp == "small")
        {
            SmokePuffs();
            paddle.transform.localScale = new Vector3(0.5f, 0.6781099f, 1);
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        PowerUpBehavior(collider);
    }
}
