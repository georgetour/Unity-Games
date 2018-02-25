using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;
    private Score score;

    private Ball ball;

    private string ballTag = "Ball";

    private LifeManager life;

    private Paddle paddle;

    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
        paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Paddle>();
    }


    //When ball hits bottom go to Win-Lose scene if life < 0 
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == ballTag)
        {
            paddle.ResizeToOriginal();
            PowerUpFireball.fireball = false; 
            
            if (LifeManager.lives <= 0)
            {
                Ball.gameStarted = false;
                levelmanager.LoadLevel("Win-Lose"); 
            }
            else
            {
            
                Ball.gameStarted = false;
                life.ContolLives(-1);
            }
            //Debug.Log(LifeManager.lives);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision");
    }
}
