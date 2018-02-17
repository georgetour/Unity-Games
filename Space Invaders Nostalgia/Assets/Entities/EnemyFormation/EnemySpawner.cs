using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {

        foreach (Transform child in transform)
        {
            //Spawn new enemy for every child EnemySpwane has
            //And keep hierarchy in editor and the Instantiation wil be a GameObject
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //Make parent wherever this script is attached to which is the Position
            enemy.transform.parent =child;
        }


        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
