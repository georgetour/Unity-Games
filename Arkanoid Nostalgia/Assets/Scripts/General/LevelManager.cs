using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Score score;
    private LifeManager life;

    Scene currentScene;
    string sceneName;

    private void Start()
    {
        
        Ball.gameStarted = false;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        score = GameObject.FindObjectOfType<Score>();
        life = GameObject.FindObjectOfType<LifeManager>();
       
       
    }


    public void LoadLevel(string name)
	{ 
        Brick.ResetBricks();
        
        //Load level according to parameter
        Application.LoadLevel(name);

        if (sceneName == "Start")
        {
            Score.ResetScore();
            LifeManager.ResetLives();
            Ball.ResetSpeed();
        }
        

    }

	public void QuitRequest()
	{
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        score.HitBrickScore(1000);
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    //If all bricks are destroyed load next level
    public void AllBricksDestroyed()
    {
        
        if (Brick.totalBricks <= 0)
        {
            Reseting.ResetPowerUps();
            LoadNextLevel();  
        }
        
    }


}
