using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTimer : MonoBehaviour
{

    public void Start()
    {
        Invoke("RemovePowerUp", 5f);   
    }
  

    public void RemovePowerUp()
    {
        Reseting.ResetPowerUps();
    }


}
