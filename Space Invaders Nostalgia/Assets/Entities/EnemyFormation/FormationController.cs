using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour {

    public GameObject enemyPrefab;

    //Width and height of the formation
    public float width = 10f;
    public float height = 5f;
    
    //Max left,right and speed of the formation
    private float xmin;
    private float xmax;
    public float speed = 5f;
    public float spawnDelay = 0.8f;

    // Use this for initialization
    void Start () {
        
        RestrictPosition();
        SpawnUntilFull();



    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
    }


    // Update is called once per frame
    void Update()
    {
        EnemiesMovement();

        if (AllMembersDead())
        {
            SpawnUntilFull();
            Destroy(gameObject);
        }
        
    }


    void RestrictPosition()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + (width/2);
        xmax = rightMost.x - (width/2);
    }


    //Move enemies right and left by reversing their direction when hit limit
    void EnemiesMovement()
    {
        this.transform.position += new Vector3(speed,0)*Time.deltaTime;
        if (transform.position.x > xmax || transform.position.x < xmin) 
        {
            speed = -(speed);
        }
    }


    //Check if all enemies have died
    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
                return false;
        }
        return true;
    }


    //Return next free position so we spawn enemies in there
    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
                return childPositionGameObject;
        }
        return null;

    }


    //Spawn new enemies
    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            //Spawn new enemy for every child EnemySpwane has
            //And keep hierarchy in editor and the Instantiation wil be a GameObject
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;

            //Make parent wherever this script is attached to which is the Position
            enemy.transform.parent = child;
        }
    }

    //Spawn enemies in free position if we have a free position
    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if(NextFreePosition())
            Invoke("SpawnUntilFull", spawnDelay);
        
    }
}
