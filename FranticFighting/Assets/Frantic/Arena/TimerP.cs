using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerP : MonoBehaviour {
    
    public float timeLeft = 2;
    public PlayerPanal PP;
    public AttackManager Manager;
    public Text CountText;
    public Text PromptText;
    public bool CountDown = false;
    public bool Ready = false;
    public bool Play = false;
    public bool Live = false;
    public Color Default = new Color(0f, 250 / 255f, 255 / 255f);
    public Color Action = new Color(255 / 255f, 240 / 255f, 0f);

    // Use this for initialization
    void Start () {
        
        StartCoroutine(ReadyUp());
        
    }
	
	// Update is called once per frame
	void Update () {

        CountText.text = "TimeLeft: " + timeLeft.ToString();
        if (Ready == false && Live == true && Manager.Casted == false)
        {
            StartCoroutine(Spell());
        }
        if (Ready == false && Live == true && Manager.Casted == true)
        {
            StopCoroutine(Spell());
            //PromptText.text = "Get Ready!";
            StartCoroutine(ReadyUp());
        }
        if (Ready == true && timeLeft > 0 )
        {
            PromptText.color = Action;
            PromptText.text = "Please Input Command to Start";
            //StopCoroutine(ReadyUp());
            Play = true;
            
            //Debug.Log("Not Here");
        }
        if (Play == true && PP.Pressed == true)
        {
            //PromptText.text = "Please Input Command to Start";
            CountDown = true;
        }
        if (timeLeft > 0 && CountDown == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            Play = false;
            Ready = false;
            CountDown = false;
            
        }
        //if (GStart.Play == true && Ready )
        
    }
    IEnumerator ReadyUp()
    {
        PromptText.color = Default;
        PromptText.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        //PromptText.text = "Please Input Command to Start";
        timeLeft = 2;
        //yield return new WaitForSeconds(1f);
        Ready = true;
        Live = true;
        StopCoroutine(ReadyUp());
    }
    IEnumerator Spell()
    {
        Debug.Log("KaBOOOM");
        PromptText.text = "Casting";
        Manager.Casting = true;
        yield return new WaitForSecondsRealtime(3f);
                
    }


}
