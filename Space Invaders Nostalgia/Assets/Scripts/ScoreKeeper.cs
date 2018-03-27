using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
        ResetScore();
	}

    //Score player gets in up right corner
    public void ScoreToGive(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
