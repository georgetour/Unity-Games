using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;


	// Use this for initialization
	void Start () {
		StartGame ();
	}

	public void StartGame()
	{
		max = 1000;
		min = 1;
		guess = 500;

		print(Color.white);

		print ("=========================");
		print ("Welcome to Number Wizard");
		print ("Pick a number in your head but don't tell me");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number higher or lower than " + guess + "?");
		print ("Up arrow = higher, down = lower, Enter = equals");

		//Fix if they choose 1000
		max = max + 1;
	}

	void NextGuess()
	{
		guess = (max + min)/2;
		print ("Higher or lower than " + guess + "?");
		print ("Up arrow = higher, down = lower, return = equals");
	}


	// Update is called once per frame
	void Update () 
	{
		//According to key pressed and with else if two buttons can't be pressed simultaneously
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			
			//This is how binary chop works in computer science
			//https://en.wikipedia.org/wiki/Binary_search_algorithm
			min = guess;
			NextGuess();

		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//The only difference is that maximum becomes the guess
			//Since you want to to not have anything above 500
			max = guess;
			NextGuess ();
		}
		//For pressing Enter
		else if (Input.GetKeyDown("return")) {
			print ("I win");
			StartGame();
		}


	}



}
