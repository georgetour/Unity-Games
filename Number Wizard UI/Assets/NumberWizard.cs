﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
    int maxGuessesAllowed;

    //Controlling the text
    public Text text;


	// Use this for initialization
	void Start () {
		StartGame ();
	}

	public void StartGame()
	{
		//We must have these values so we can start using where the number is between
		max = 1000;
		min = 1;
        maxGuessesAllowed = 5;
        //Gives a random number at start instead of a fixed
        guess = Random.Range (1, 1000);
        StartCoroutine(WaitText());
        
		//Fix if they choose 1000
		max = max + 1;
	}


	void NextGuess()
	{
		guess = (max + min)/2;
        text.text = Guess();
        maxGuessesAllowed = maxGuessesAllowed -  1;
        Debug.Log(maxGuessesAllowed);
        if (maxGuessesAllowed <= 0)
        {
            Application.LoadLevel("Lose");
        }
		
	}

    //If we have number higher
    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    //If we have number lower
    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    //Starting questions with timers
    IEnumerator WaitText()
    {
            yield return new WaitForSeconds(3.0f);
            text.fontSize = 28;
            text.text = "Choose a number from 1 - 1000 \n and I'll find it";
            yield return new WaitForSeconds(5.0f);
            text.fontSize = 40;
            text.text = Guess();
    }

    public string Guess()
    {
        return "Is your number \n" + guess + "?";
    }



}
