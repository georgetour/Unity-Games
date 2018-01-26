using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;
    private Score score;

    private Ball ball;

    private LifeManager life;

    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
        
    }


    //When ball hits bottom go to Win-Lose scene
    private void OnTriggerExit2D(Collider2D collider)
    {
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
        Debug.Log(LifeManager.lives);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision");
    }
}
