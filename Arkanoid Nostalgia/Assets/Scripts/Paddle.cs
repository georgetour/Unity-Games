using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        //Get mouse position in game units
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;

        //Limit left right so it doesn't leave the screen
        float maxLeftRightPosition = Mathf.Clamp(mousePosInBlocks, 0.63f, 18.65f);

        //Set where the paddle starts
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        
        
        //Set mouse position horizontally
        paddlePos.x = maxLeftRightPosition;

        this.transform.position = paddlePos;
	}
}
