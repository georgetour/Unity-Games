using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

    public float fadeTime;

    private Image fadePANEL;
    private Color currentColor = Color.black;


	// Use this for initialization
	void Start () {

        fadePANEL = GetComponent<Image>();
   
	}

    private void Update()
    {
        if (Time.timeSinceLevelLoad < fadeTime)
        {
            fadeIn();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    //This fades the panel so the scene appears smoothly and not suddelnly
    void fadeIn()
    {
        //Fade In
        float alphaChange = Time.deltaTime / fadeTime;
        //Change alpha
        currentColor.a -= alphaChange;
        fadePANEL.color = currentColor;

    }


	

   
}
