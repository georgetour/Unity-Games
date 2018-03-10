using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerStart : Reseting {

    private Text counter;
    public static bool startTimer;

	// Use this for initialization
	public void Start () {

        counter = GetComponent<Text>();
        startTimer = true;
        counter.text = "";
        if(startTimer)
            StartCoroutine(CountDown());
        
    }
	
    //Countdown in start level or when ball hits bottom
    IEnumerator CountDown()
    {

        counter.text = "3";
        yield return new WaitForSeconds(1.0f);
        counter.text = "2";
        yield return new WaitForSeconds(1.0f);
        counter.text = "1";
        yield return new WaitForSeconds(1.0f);
        counter.text = "Go";
        yield return new WaitForSeconds(0.5f);
        counter.text = "";
        startTimer = false;
        
        ResetPaddle();
        yield return new WaitForSeconds(0.3f);
        EnablePaddleAndBall(true);
    }
}
