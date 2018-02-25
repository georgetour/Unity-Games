using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPowerUp : MonoBehaviour {

    [System.Serializable]
    public class PowerUp
    {
        public string name;
        public GameObject powerUp;
        public int dropRarity;
        
    }


    public List<PowerUp> PowerUpTable = new List<PowerUp>();
    public int dropChance; 
   

    int number;
    

    //Make powerup appear when brick is destroyed
    public void Activate(Vector3 position)
    {
        
       
        randomNumber();
        int calc_dropChance = randomNumber();
        if (calc_dropChance > dropChance)
        {
            //Debug.Log("no power up");
            return;
        }
        else if(calc_dropChance <= dropChance)
        {
            int powerUpWeight = 0;
            for (int i = 0; i < PowerUpTable.Count; i++)
            {
                powerUpWeight += PowerUpTable[i].dropRarity;
            }
            //Debug.Log(string.Format("Power up weight {0}", powerUpWeight));

            int randomValue = Random.Range(0, powerUpWeight);

            for (int j = 0; j < PowerUpTable.Count; j++)
            {
                if (randomValue <= PowerUpTable[j].dropRarity)
                {
                    Instantiate(PowerUpTable[j].powerUp,position,Quaternion.identity );
                    return;
                }
                randomValue -= PowerUpTable[j].dropRarity;
               // Debug.Log("random value decreased" + randomValue);
            }

        }
    }

    //Create random number so accordingly we give the power up
    public int randomNumber()
    {
        number = Random.Range(0, 101);
        return number;
    }



}
