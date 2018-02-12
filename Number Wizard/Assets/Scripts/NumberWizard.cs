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
		//We must have these values so we can start using where the number is between
		max = 1000;
		min = 1;

		//Gives a random number at start instead of a fixed
		guess = Random.Range (1, 1000);

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

	//This is how binary search / binary chop works in computer science
	//https://en.wikipedia.org/wiki/Binary_search_algorithm
	void NextGuess()
	{
		guess = (max + min)/2;
		print ("Higher or lower than " + guess + "?");
		print ("Up arrow = higher, down = lower, return = equals");
	}


	// Update is called once per frame
	void Update () 
	{

		//If the up key is pressed min must change 
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			

			min = guess;
			//print (min);
			//print (max);
			NextGuess();

		}
		//Chnage max value if down key pressed
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//The only difference is that maximum becomes the guess
			//Since you want to to not have anything above 500
			max = guess;
			//print (min);
			//print (max);
			NextGuess ();
            
		}
		//For pressing Enter
		else if (Input.GetKeyDown("return")) {
			print ("I win");
			StartGame();
		}


	}



}
