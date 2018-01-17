using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;
    private Score score;

    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();
        score.ResetScore();
    }


    //When ball hits bottom go to Win-Lose scene
    private void OnTriggerExit2D(Collider2D collider)
    {
        levelmanager.LoadLevel("Win-Lose");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision");
    }
}
