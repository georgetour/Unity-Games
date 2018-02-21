using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPaddle : ControlPowerUps {

	public override void PowerUpBehavior()
    {
        paddle.transform.localScale += new Vector3(0.2f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == paddleTag)
        {
            Debug.Log("hello");
            PowerUpBehavior();
            Destroy(gameObject);
        }
        else if (collision.transform.tag == loseTag)
        {
            Destroy(gameObject);
        }
    }
}
