using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPowerUp : MonoBehaviour {

    public GameObject powerUp;

    

    private void Start()
    {
       

    }
    

    //Make powerup appear when brick is destroyed
    public void Activate(Vector3 position)
    {
        Instantiate(powerUp, position, Quaternion.identity);
    }
}
