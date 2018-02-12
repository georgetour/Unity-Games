using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Move speed
    public float shipSpeed = 15f;


	// Use this for initialization
	void Start () {
        StartingPosition();
    }
	
	// Update is called once per frame
	void Update () {
        
        MoveWithArrows();
	}


    //Move ship right and left
    void MoveWithArrows()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(shipSpeed *Time.deltaTime, 0, 0);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-shipSpeed * Time.deltaTime, 0, 0);
        }
    }

    void StartingPosition()
    {
        //Starting position
        Vector3 shipStartingPos = new Vector3(0f, -4f, 1f);

        this.transform.position = shipStartingPos;
    }

   
}
