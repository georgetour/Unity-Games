using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseting : MonoBehaviour {

    private Paddle paddle;

    // Use this for initialization
    void Awake () {
        paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Paddle>();
    }


    public void ResetPaddle()
    {
        paddle.transform.position = new Vector3(9.6f, 0.51f,0);
        paddle.ResizeToOriginal();
    }

    public static void ResetPowerUps()
    {
        PowerUpFireball.fireball = false;
        PowerUpLaser.laser = false;
    }

    public void DestroyPaddle()
    {
        paddle.transform.position = new Vector3(-500f, -500f, -20f);
    }






}


