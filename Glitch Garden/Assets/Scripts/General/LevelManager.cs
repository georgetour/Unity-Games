using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

   
    Scene currentScene;
    string sceneName;

    float secondsToLoad = 3;

    private void Start()
    {
        
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        //Load start screen after splassh screen some seconds
        if (sceneName == "Splash")
        {
            StartCoroutine(CountDown());
        }
    }


    public void LoadLevel(string name)
	{
        //Load level according to parameter
        SceneManager.LoadScene(name);

    }

	public void QuitRequest()
	{
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(secondsToLoad);
        LoadNextLevel();
    }

    //Open external link at click
    public void OpenLinkAtclick(string url)
    {
        Application.OpenURL(url);
    }


    }
