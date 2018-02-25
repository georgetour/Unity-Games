using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPLay = true;

    private Ball ball;

    public float speed = 10f;

    private float xmin;
    private float xmax;

    private float size;



    // Use this for initialization
    void Start () {
        
        
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        paddleScale();
        RestrictPosition();
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
        float maxLeftRightPosition = Mathf.Clamp(ballPosition.x, xmin, xmax);
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }

  


    void MoveWithMouse()
    {
        //Get mouse position in game units
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;

        //Restrict player from leaving boundaries
        float maxLeftRightPosition = Mathf.Clamp(mousePosInBlocks, xmin, xmax);
        //transform.position = new Vector3(maxLeftRightPosition, transform.position.y, transform.position.z);


        //Set where the paddle starts according to position.y which set in Unity and fixed x
        Vector3 paddlePos = new Vector3(0.6f, this.transform.position.y, 0f);


        //Move paddle horizontally according to mouse
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }

    public void ResizeToOriginal()
    {
        this.transform.localScale = new Vector3(0.65f, 0.6781099f, 1);

    }


    void RestrictPosition()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x  + paddleScale();
        xmax = rightMost.x - paddleScale();
    }


    //Check paddlesize
    public float paddleScale()
    {
        size = this.transform.localScale.x+0.1f;

        return size;
    }




    
}
