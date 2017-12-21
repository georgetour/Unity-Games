using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		//Write to console that the click works
		Debug.Log ("Level load requested for:" + name);

		//Load level according to parameter
		Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Debug.Log ("Quit requested ");
		Application.Quit ();
	}


}
