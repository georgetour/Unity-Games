using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPLay = true;
    public Sprite[] paddleSprite;
    int spriteIndex = 1;//The laser sprites
    private Ball ball;

    public PowerUpTimer timer { get; private set; }

    public float speed = 10f;

    private float xmin;
    private float xmax;

    private float size;

    //Lasers
    public float fireRate;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    private float nextFire;
    

    // Use this for initialization
    void Start () {
        this.transform.position = new Vector2(9.6f,0.51f);
        ball = GameObject.FindObjectOfType<Ball>();
        timer = GetComponent<PowerUpTimer>();
        
    }

   
	
	// Update is called once per frame
	void Update () {

        
        paddleScale();
        LasersSprite();
        RestrictPosition();
        
        //Fire laser if laser is active
        if (Time.time > nextFire && PowerUpLaser.laser){
            nextFire = Time.time + fireRate;
            Fire(0.75f);
            Fire(-0.75f);
        }

        if (autoPLay == false && !TimerStart.startTimer)
        {
            //MoveWithArrows();
            MoveWithMouse();
        }
        else if (autoPLay == true && !TimerStart.startTimer)
        {
            Autoplay();
        }

       
	}

    void Fire(float xPosition)
    {
        Laser.CreateLasers(projectile, new Vector3(this.transform.position.x+xPosition, this.transform.position.y + 0.8f, 0),projectileSpeed);
        
    }

    //Move the mouse automatically according to ball
    private void Autoplay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPosition = ball.transform.position;
        float maxLeftRightPosition = Mathf.Clamp(ballPosition.x, xmin, xmax);
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }


    //Move ship right and left
    void MoveWithArrows()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(speed *Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
            //transform.position += new Vector3(-shipSpeed * Time.deltaTime, 0, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;



        //Restrict player from leaving boundaries
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }



    void MoveWithMouse()
    {
        //Get mouse position in game units
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 20;

        //Restrict player from leaving boundaries
        float maxLeftRightPosition = Mathf.Clamp(mousePosInBlocks, xmin, xmax);
        //transform.position = new Vector3(maxLeftRightPosition, transform.position.y, transform.position.z);


        //Set where the paddle starts according to position.y which set in Unity and fixed x
        Vector3 paddlePos = new Vector3(0.6f, this.transform.position.y, 0f);


        //Move paddle horizontally according to mouse
        paddlePos.x = maxLeftRightPosition;
        this.transform.position = paddlePos;
    }

    public void ResizeToOriginal()
    {
        this.transform.localScale = new Vector3(0.65f, 0.6781099f, 1);
        
    }


    void RestrictPosition()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + paddleScale();
        xmax = rightMost.x - paddleScale();


    }

    //Check paddlesize
    public float paddleScale()
    {
        size = GetComponent<Renderer>().bounds.size.x - GetComponent<Renderer>().bounds.size.x/2 + 0.1f;
        return size;
    }

    void LasersSprite()
    {
        if (PowerUpLaser.laser)
        {
            timer.Start();
            this.GetComponent<SpriteRenderer>().sprite = paddleSprite[spriteIndex];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = paddleSprite[0];
        }
    }




    
}
