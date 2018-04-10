
using UnityEngine;

public class PowerUpLaser : ControlPowerUps {

    public static bool laser = false;
    public int scoreToGive;


    private PowerUpTimer timer;

    public override void PowerUpBehavior(Collider2D collision)
    {
        if (collision.transform.tag == paddleTag)
        {
            
            SmokePuffs();
            score.HitBrickScore(scoreToGive);
            laser = true;
            
        }


    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpBehavior(collision);
    }




}
