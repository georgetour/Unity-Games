using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;
    private Score score;

    private Ball ball;

    private string ballTag = "Ball";

    private LifeManager life;

    private Reseting reseting;

    private TimerStart timer;
    

    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        life = GameObject.FindObjectOfType<LifeManager>();
        reseting = GameObject.FindGameObjectWithTag("Reseting").GetComponent<Reseting>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerStart>();

    }

    private void Update()
    {
        Debug.Log(TimerStart.startTimer);
    }


    //When ball hits bottom go to Win-Lose scene if life < 0 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == ballTag)
        {

            reseting.EnablePaddleAndBall(false);
            timer.Start();

            if (LifeManager.lives <= 0)
            {
                Ball.gameStarted = false;
                levelmanager.LoadLevel("Win-Lose"); 
            }
            else
            {
            
                Ball.gameStarted = false;
                life.ContolLives(-1);
            }
            //Debug.Log(LifeManager.lives);
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }

   
}
