using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

 
	public void LoadLevel(string name)
	{
		//Load level according to parameter
		Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
       Application.LoadLevel(Application.loadedLevel + 1);
    }


}
