using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerStart:MonoBehaviour {

    private Text counter;
    private Reseting reseting;
    public static bool startTimer;
    public static bool paddleDestroyed;

	// Use this for initialization
	public void Start () {

        reseting = GameObject.FindGameObjectWithTag("Reseting").GetComponent<Reseting>();
        counter = GetComponent<Text>();
        startTimer = true;
        counter.text = "";
        if(startTimer)
            StartCoroutine(CountDown());
        
    }
	
    //Countdown in start level or when ball hits bottom
    IEnumerator CountDown()
    {
        if (paddleDestroyed)
            reseting.DestroyPaddle();
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
        if (paddleDestroyed)
            reseting.ResetPaddle();
        yield return new WaitForSeconds(0.3f);
        paddleDestroyed = false;

    }
}
