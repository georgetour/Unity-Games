using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
    }
}
