using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    public static int score = 0;



    private void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void HitBrickScore(int scorePoints)
    {
        Debug.Log("score");
        score += scorePoints;
        scoreText.text = score.ToString();
        
    }

    public void ResetScore()
    {
        score = 0;
    }


    //******** todo power up score
    void PowerUpscore()
    {

    }

}
