using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseting : MonoBehaviour {

    private Paddle paddle;

    private Ball ball;


    // Use this for initialization
    void Awake () {
        paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Paddle>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        
    }
	
	

    public void ResetPaddle()
    {
        
        paddle.transform.position = new Vector2(9.6f, 0.51f);
        paddle.ResizeToOriginal();
        
        
    }

    public void ResetPowerUps()
    {
        PowerUpFireball.fireball = false;
        PowerUpLaser.laser = false;
    }


    public void EnablePaddleAndBall(bool activate)
    {
        paddle.GetComponent<SpriteRenderer>().enabled = activate;
        ball.GetComponent<SpriteRenderer>().enabled = activate;
        paddle.GetComponent<CapsuleCollider2D>().enabled = activate;
        ball.GetComponent<CircleCollider2D>().enabled = activate;
    }
       


}


