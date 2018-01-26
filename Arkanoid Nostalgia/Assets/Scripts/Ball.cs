using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    //Check if game has started
    public static bool gameStarted = false;

    //Distance between ball and paddle
    private Vector3 paddleToBallVector;
    


	// Use this for initialization
	void Start () {
        //Connecting programmatically the paddle with the Paddle class
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!gameStarted)
            ballStartingPosition();
      
        //Start the game with mouse press and launch the ball
        if (Input.GetMouseButtonDown(0)&&!gameStarted)
        {
            gameStarted = true;
            
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,9f);
        }
    }

    //Set starting position of the ball to be the same with paddle
    public void ballStartingPosition()
    {
        
        transform.position = paddle.transform.position + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Fix the second parameter if ball can't reach top or stays in loop
        Vector2 tweak = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));

        if (gameStarted==true)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
       
    }

}
