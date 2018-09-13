using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerP : MonoBehaviour {
    
    public float timeLeft = 2;
    public PlayerPanal PP;
    public Master Master;
    public AttackManager Manager;
    public Text CountText;
    //public Text CountTextP2;
    public Text PromptText;
    public string AttackTextPrompt;
    public string AttackTextL;
    public string AttackTextR;
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
        
        if (Ready == false && Live == true && Manager.Casting == true && Manager.Casted == true)
        {
            StartCoroutine(Spell());
        }
        if (Ready == false && Live == true && Manager.Casting == false && Manager.TurnOver == true)
        {
            StopCoroutine(Spell());
            //PromptText.text = "Get Ready!";
            StartCoroutine(ReadyUp());
            //Live = false;
        }
        if (Ready == true && timeLeft > 0 && Manager.TurnOver == false)
        {
            PromptText.color = Action;
            PromptText.text = "Please Input Command to Start";
            Play = true; 
        }
        if (Play == true && PP.Pressed == true)
        {
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
            Manager.Casting = true;
        }
        //if (GStart.Play == true && Ready )
        
    }
    IEnumerator ReadyUp()
    {
        Debug.Log("Ready!");
        PromptText.color = Default;
        PromptText.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        //PromptText.text = "Please Input Command to Start";
        timeLeft = 3;
        //yield return new WaitForSeconds(1f);
        Ready = true;
        Live = true;
        Manager.TurnOver = false;
        Manager.Casted = false;
        Manager.LeftMan.Casted = false;
        Manager.RightMan.Casted = false;
        PP.Left = false;
        PP.Right = false;
        PP.RightAtk = false;
        PP.RightDef = false;
        PP.LeftAtk = false;
        PP.LeftDef = false;
        PP.TotaledUp = false;
        StopCoroutine(ReadyUp());
    }

    IEnumerator Spell()
    {
        if (PP.Right == true && PP.Left == true)
        {
            AttackTextPrompt = AttackTextL + " & " + AttackTextR;
        }
        if (PP.Right == true && PP.Left == false)
        {
            AttackTextPrompt = AttackTextR;
        }
        if (PP.Left == true && PP.Right == false)
        {
            AttackTextPrompt = AttackTextL;
        }
        PromptText.text = AttackTextPrompt;
        //PromptText.text = "Casting";
        yield return new WaitForSeconds(3f);
        Manager.Casting = false;        
    }


}
