﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {

        //Spawn new enemy 
        //And keep hierarchy in editor and the Instantiation wil be a GameObject
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0),Quaternion.identity)as GameObject;
        
        //Make parent wherever this script is attached to
        enemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
