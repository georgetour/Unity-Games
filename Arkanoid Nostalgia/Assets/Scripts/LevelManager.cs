using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    Score score;
    

    public void LoadLevel(string name)
	{
        
        Brick.ResetBricks();
        //Load level according to parameter
        Application.LoadLevel(name);
	}

	public void QuitRequest()
	{
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        Brick.ResetBricks();
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    //If all bricks are destroyed load next level
    public void AllBricksDestroyed()
    {
        
        if (Brick.totalBricks <= 0)
        { 
            LoadNextLevel();  
        }
        
    }


}
