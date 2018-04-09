
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    //Check if game has started
    public static bool gameStarted = false;

    //Distance between ball and paddle
    private Vector3 paddleToBallVector;

    private ParticleSystem particle;

    Vector2 tweak;

    // Use this for initialization
    void Start () {
        
        particle = GetComponent<ParticleSystem>();
        
        //Connecting programmatically the paddle with the Paddle class
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        

    }
	
	// Update is called once per frame
	void Update () {
        var emission = particle.emission; 
        if (PowerUpFireball.fireball)
            emission.enabled = true;
        else if (!PowerUpFireball.fireball)
            emission.enabled = false;

        if (!gameStarted)
            ballStartingPosition();

        if (!TimerStart.startTimer)
            LaunchBallWithMouse();
       
    }

    //Set starting position of the ball to be the same with paddle
    public void ballStartingPosition()
    { 
        transform.position = paddle.transform.position + paddleToBallVector;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Fix the x parameter if ball can't reach top or stays in loop
        tweak = new Vector3(Random.Range(-0.05f, 0.6f), Random.Range(-0.05f, 0.3f));

        if (gameStarted==true)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
            
        }
       
    }

    void LaunchBallWithMouse()
    {
        //Start the game with mouse press and launch the ball
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;

            //Ball spee launch
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 7.2f);
            
        }

        //Start the game with mouse press and launch the ball
        if (Input.GetKeyDown("space") && !gameStarted)
        {
            gameStarted = true;

            //Ball spee launch
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 7.2f);
        }
    }

}
