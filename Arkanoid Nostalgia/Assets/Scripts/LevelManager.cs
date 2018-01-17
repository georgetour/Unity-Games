using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    Score score;
    

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

    //If all bricks are destroyed load next level
    public void AllBricksDestroyed()
    {
        //Total bricks for current scene
        int totalBricks = Brick.totalBricks;

        
        if(totalBricks <= 0)
        {
            LoadNextLevel();
        }
        
    }


}
