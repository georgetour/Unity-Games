using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;

    //Check if game has started
    private bool gameStarted = false;

    //Distance between ball and paddle
    private Vector3 paddleToBallVector;

    


	// Use this for initialization
	void Start () {
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
            print("gave velocity");
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,10f);
        }
    }

    //Set starting position of the ball to be the same with paddle
    void ballStartingPosition()
    {
        this.transform.position = paddle.transform.position + paddleToBallVector;
    }
}
