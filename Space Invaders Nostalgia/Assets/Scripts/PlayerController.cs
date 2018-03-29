using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Move speed
    public float speed = 15f;
    public float padding = 1f;
    public float health = 250;

    float xmin;
    float xmax;

    public float laserSpeed ;
    public float firingRate = 0.2f;

    public List<Projectile> weapons = new List<Projectile>();
    public static int currentWeapon = 0;


    // Use this for initialization
    void Start ()
    {

        StartingPosition();
        RestrictPosition();
    }
	
	// Update is called once per frame
	void Update () {
        
        MoveWithArrows();
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        //Check if the collider was a projectile
        
        //projectile = collider.gameObject.GetComponent<Projectile>();
        if (weapons[currentWeapon])
            health -= weapons[currentWeapon].GetDamage();


        Destroy(collider.gameObject);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }


    //Shoot projectiles
    void Fire()
    {
        
        GameObject beam = Instantiate(weapons[currentWeapon].gameObject, new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, 0), Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        weapons[currentWeapon].LaunchSound();


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

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            //InvokeRepeating("Fire", 0.0000001f, firingRate);
        }

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    CancelInvoke("Fire");
        //}

        //Restrict player from leaving boundaries
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void RestrictPosition()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    void StartingPosition()
    {
        //Starting position
        Vector3 shipStartingPos = new Vector3(0f, -4f, 1f);

        this.transform.position = shipStartingPos;
    }

   
}
