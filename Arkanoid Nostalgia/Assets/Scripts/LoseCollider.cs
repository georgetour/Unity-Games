using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;
    private Score score;

    private Ball ball;

    private Life life;

    private void Start()
    {
        
        Debug.Log(Ball.gameStarted);
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();
        life = GameObject.FindObjectOfType<Life>();
        
        score.ResetScore();
    }


    //When ball hits bottom go to Win-Lose scene
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (0<= 0)
        {
            Ball.gameStarted = false;
            levelmanager.LoadLevel("Win-Lose");
        }
        else
        {
            
            Ball.gameStarted = false;
            //life.lives -= life.lives;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision");
    }
}
