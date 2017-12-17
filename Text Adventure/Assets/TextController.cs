using UnityEngine;
using UnityEngine.UI;//Whenever we use a UI element we need this namespace
using System.Collections;

public class TextController : MonoBehaviour {

	//To have access to the text
	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "Press space to start";
	}
	
	// Update is called once per frame
	void Update () {

		//For pressing the space
		if (Input.GetKeyDown("space")) {
			text.text = "You are in a Prison Cell. \n" +
						"You don't remember what happened or how you got there. \n" +
						"It's cold and you feel weak. \n" +
						"Screams are spread in the coriddor. \n\n" +
						"Press S to view Sheets, M to view Mirror, L to view Lock ";
		}
	
	}
}
