
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
        score += scorePoints;
        scoreText.text = score.ToString();
        
    }

    public static  void ResetScore()
    {
        score = 0;
    }

    

}
