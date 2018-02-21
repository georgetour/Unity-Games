using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : ControlPowerUps {

    public string powerUp;

	public override void PowerUpBehavior(Collider2D collision)
    {
        

        if (collision.transform.tag == paddleTag &&  powerUp == "big")
        {
            SmokePuffs();
            paddle.transform.localScale = new Vector3(0.8f, 0.6781099f, 1); 
        }
        else if (collision.transform.tag == paddleTag && powerUp == "small")
        {
            SmokePuffs();
            paddle.transform.localScale = new Vector3(0.5f, 0.6781099f, 1);
        }

        //TODO ADD LASER

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
