
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip[] crack;
    public Sprite[] hitSprites;

    //Totalbricks that we will access in levelmanager
    public static int totalBricks=0;

    private LevelManager levelmanager;
    public GameObject smoke;

    private Score score;

    //How many times have been hit
    private int timesHit;

    bool isBreakable;

    //Powerup
    private LoadPowerUp loadPowerUp;


    // Use this for initialization
    void Start()
    {
        
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        score = GameObject.Find("Score").GetComponent<Score>();
        
        //Set our bricks that have tag Breakable to isBreakable
        isBreakable = (tag == "Breakable");
        
        //Count all bricks that are breakables
        if (isBreakable)
        {
            totalBricks++;
        }
       
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        loadPowerUp = GameObject.FindObjectOfType<LoadPowerUp>();
        timesHit = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (PowerUpFireball.fireball )
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if (!PowerUpFireball.fireball )
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }

       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Handle hits only if you can break it
        if (!PowerUpFireball.fireball && isBreakable)
        {
            HandleHits();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (PowerUpFireball.fireball && isBreakable)
        {
            int maxHits = 0;

            if (timesHit >= maxHits)
            {
                Destroy(gameObject);
                totalBricks--;
                levelmanager.AllBricksDestroyed();
                AudioSource.PlayClipAtPoint(crack[1], transform.position);
                SmokePuffs();
                loadPowerUp.Activate(new Vector3(this.transform.position.x, this.transform.position.y, -9));
                score.HitBrickScore(100);
            }
        }

    }

    void HandleHits()
    {
        timesHit++;
        
        //How many times it can be hit

        //TODO CONTROL ACCORDING TO FIREBALL
        int maxHits = hitSprites.Length + 1;

        //Destroy brick on maxhits and remove the total counter for bricks
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
            totalBricks--;
            levelmanager.AllBricksDestroyed();
            AudioSource.PlayClipAtPoint(crack[1], transform.position);
            SmokePuffs();
            loadPowerUp.Activate(new Vector3(this.transform.position.x,this.transform.position.y,-9));
            score.HitBrickScore(100);
            
        }
        else
        {
            LoadSprites();
            score.HitBrickScore(20);
        }
        AudioSource.PlayClipAtPoint(crack[0], transform.position);
    }

    //Handle the particle when brick is destroyed
    private void SmokePuffs()
    {
        var smokePuff = Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
        //Destroy smokepuff after 2 seconds so you don't get unlimited Smoke clones
        Destroy(smokePuff, 2f);
    }


    private void LoadSprites()
    {
        //Find Array indexer according to times hit so if hit one time the array ndexer will be 0
        int spriteIndex = timesHit - 1;

        //Find component sprite renderer and change it according to index
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
                Debug.LogError("Missing sprite");
        }

    }

    //Reset bricks for next lext etc
    public static void ResetBricks()
    {
        totalBricks = 0;
    }

    //TODO Remove this method when we can actually win
    private void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }

}
