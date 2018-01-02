using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    public LevelManager levelmanager ;

    //When ball hits bottom return to main menu
    private void OnTriggerEnter2D(Collider2D collider)
    {
        levelmanager.LoadLevel("Win-Lose");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
    }
}
