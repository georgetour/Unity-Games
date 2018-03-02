using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Projectile projectile;
    public float health = 250;

    public GameObject enemyProjectile;
    public float projectileSpeed = 10f;
    public float firerate= 0.5f;
    //private float probability;

    private void Update()
    {
        float probability = Time.deltaTime * firerate;
        if (Random.value < probability)
        {
            Fire();
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        //Check if the collider was a projectile
        projectile = collider.gameObject.GetComponent<Projectile>();
        if (projectile)
            health -= projectile.GetDamage();

       
        Destroy(collider.gameObject);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
                
    }

    //Make the enemy shoot
    void Fire()
    {
        GameObject beam = Instantiate(enemyProjectile, new Vector3(transform.position.x, transform.position.y - 1f, 0), Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }




}
