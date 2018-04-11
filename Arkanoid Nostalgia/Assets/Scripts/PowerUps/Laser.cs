using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    

    //Create lasers where we want and with speed we want
    public static void CreateLasers(GameObject projectile, Vector3 position, float projectileSpeed)
    {
        
        GameObject beam = Instantiate(projectile, position, Quaternion.identity);
 
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }




}
