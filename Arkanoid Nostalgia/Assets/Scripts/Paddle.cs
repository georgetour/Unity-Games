using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPLay = true;
    public float maxXPosition, maxYPosition;

    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if (autoPLay == false)
            MoveWithMouse();
        else
            Autoplay();
       
	}

    //Move the mouse automatically according to ball
    private void Autoplay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        float maxLeftRightPosition = Mathf.Clamp(ballPosition.x, maxXPosition, maxYPosition);
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        //Get mouse position in game units
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;

        //Limit left right so it doesn't leave the screen
        float maxLeftRightPosition = Mathf.Clamp(mousePosInBlocks, maxXPosition,maxYPosition);

        //Set where the paddle starts according to position.y which set in Unity and fixed x
        Vector3 paddlePos = new Vector3(0.6f, this.transform.position.y, 0f);


        //Move paddle horizontally according to mouse
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }
}
