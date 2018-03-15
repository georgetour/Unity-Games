using UnityEngine;

public class LoseCollider : MonoBehaviour {

    //Access to level manager
    private LevelManager levelmanager ;

    private LifeManager life;
    private Reseting reseting;
    private TimerStart timer;

    private string ballTag = "Ball";


    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<LevelManager>(); 
        life = GameObject.FindObjectOfType<LifeManager>();
        reseting = GameObject.FindGameObjectWithTag("Reseting").GetComponent<Reseting>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerStart>();

    }



    //When ball hits bottom go to Win-Lose scene if life < 0 and reset the paddle and ball
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == ballTag)
        {
            TimerStart.paddleDestroyed = true;
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
            Reseting.ResetPowerUps();
        }
        else
        {
            Destroy(collider.gameObject);
        }
    }

   
}
