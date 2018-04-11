
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;



    //Check if game has started
    public static bool gameStarted = false;

    //Distance between ball and paddle
    private Vector3 paddleToBallVector;

    private ParticleSystem particle;

    public static float ballSpeed = 8.5f;

    private PowerUpTimer timer;

    // Use this for initialization
    void Start () {
        
        particle = GetComponent<ParticleSystem>();
        
        //Connecting programmatically the paddle with the Paddle class
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        timer = GetComponent<PowerUpTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        var emission = particle.emission;
        if (PowerUpFireball.fireball)
        {
            emission.enabled = true;
            timer.Start();
        }
        else if (!PowerUpFireball.fireball)
            emission.enabled = false;

        if (!gameStarted)
            ballStartingPosition();

        if (!TimerStart.startTimer)
            LaunchBallWithMouse();
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    //Set starting position of the ball to be the same with paddle
    public void ballStartingPosition()
    { 
        transform.position = paddle.transform.position + paddleToBallVector;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Fix the x parameter if ball can't reach top or stays in loop
        Vector2 tweak = new Vector2(Random.Range(-2, 0.2f)* Time.deltaTime, Random.Range(0f, 0.4f));
        
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, ballSpeed);
            
        }

        //Start the game with mouse press and launch the ball
        if (Input.GetKeyDown("space") && !gameStarted)
        {
            gameStarted = true;

            //Ball spee launch
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 7.2f);
        }


        
    }

    public static void ResetSpeed()
    {
        ballSpeed = 8f;
    }

}
