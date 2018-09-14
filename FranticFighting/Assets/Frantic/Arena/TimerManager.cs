using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public PlayerPanal P1;
    public PlayerPanal P2;
    public float P1_timeLeft = 3;
    public float P2_timeLeft = 3;
    public Master Master;
    public AttackManager P1_ATKman;
    public AttackManager P2_ATKman;
    public Text P1_CountText;
    public Text P2_CountText;
    public Text P1_PromptText;
    public Text P2_PromptText;
    public string P1_AttackTextPrompt;
    public string P1_AttackTextL;
    public string P1_AttackTextR;
    public string P2_AttackTextPrompt;
    public string P2_AttackTextL;
    public string P2_AttackTextR;
    public bool P1_CountDown = false;
    public bool P2_CountDown = false;
    public bool P1_Ready = false;
    public bool P2_Ready = false;
    public bool P1_Play = false;
    public bool P2_Play = false;
    public bool GameIsLive = false;
    public bool P1_Live = false;
    public bool P2_Live = false;
    public bool P1_TimeIsUp;
    public bool P2_TimeIsUp;
    public bool ATKphase;
    public bool P1_TallyTime;
    public bool P2_TallyTime;
    public Color Default = new Color(0f, 250 / 255f, 255 / 255f);
    public Color Action = new Color(255 / 255f, 240 / 255f, 0f);

    // Use this for initialization
    void Start()
    {

        StartCoroutine(P1_ReadyUp());
        StartCoroutine(P2_ReadyUp());

    }

    // Update is called once per frame
    void Update()
    {
        if (P1_Live == true && P2_Live == true)
        {
            GameIsLive = true;
        }

        P1_CountText.text = "TimeLeft: " + P1_timeLeft.ToString();
        P2_CountText.text = "TimeLeft: " + P2_timeLeft.ToString();

        if (P1_TimeIsUp == true && P2_TimeIsUp == true)
        {
            ATKphase = true;
        }
        if (P1_TimeIsUp == true && P1.CanTotal == false && P1_TallyTime == true && P1_timeLeft <= 0)
        {
            P1.CanTotal = true;
        }
        if (P2_TimeIsUp == true && P2.CanTotal == false && P2_TallyTime == true && P2_timeLeft <= 0)
        {
            P2.CanTotal = true;
        }

        if (P1.CanTotal == true)
        {
            P1_TallyTime = false;
        }
        if (P2.CanTotal == true)
        {
            P2_TallyTime = false;
        }

        if (P1_Ready == false && P2_Ready == false && ATKphase == true && P1_ATKman.Casted == true)
        {
            StartCoroutine(P1_SpellText());
            P1_ATKman.Casted = false;          
        }
        if (P1_Ready == false && P2_Ready == false && ATKphase == true && P2_ATKman.Casted == true)
        {
            StartCoroutine(P2_SpellText());
            P2_ATKman.Casted = false;
        }

        if (P1_timeLeft <= 0 && P1_Ready == false && P2_Ready == true && Master.NewTurn == false)
        {
            P1_PromptText.text = "Waiting On Player 2";
        }
        if (P2_timeLeft <= 0 && P2_Ready == false && P1_Ready == true && Master.NewTurn == false)
        {
            P2_PromptText.text = "Waiting On Player 1";
        }
        if (P1_Ready == false && GameIsLive == true && Master.NewTurn == true)
        {
            StopCoroutine(P1_SpellText());
            StartCoroutine(P1_ReadyUp());
            //P1.CanPause = true;
            P1_Ready = true;
        }
        if (P2_Ready == false && GameIsLive == true && Master.NewTurn == true)
        {
            StopCoroutine(P2_SpellText());
            StartCoroutine(P2_ReadyUp());
            //P2.CanPause = true;
            P2_Ready = true;
        }

        if (P1_Ready == true && P2_Ready == true && P1_timeLeft > 0 && P2_timeLeft > 0 && Master.NewTurn == false)
        {
            P1_PromptText.color = Action;
            P1_PromptText.text = "Please Input Command to Start";
            P2_PromptText.color = Action;
            P2_PromptText.text = "Please Input Command to Start";
            P1_Play = true;
            P2_Play = true;
        }

        if (P1_Play == true && P1.Pressed == true)
        {
            P1_CountDown = true;
        }
        if (P2_Play == true && P2.Pressed == true)
        {
            P2_CountDown = true;
        }

        if (P1_timeLeft > 0 && P1_CountDown == true)
        {
            P1_timeLeft -= Time.deltaTime;
        }
        if (P2_timeLeft > 0 && P2_CountDown == true)
        {
            P2_timeLeft -= Time.deltaTime;
        }

        if (P1_timeLeft <= 0)
        {
            P1_timeLeft = 0;
            P1_Play = false;
            P1_Ready = false;
            P1_CountDown = false;
            P1_TimeIsUp = true;
            //P1_ATKman.Casting = true;
        }
        if (P2_timeLeft <= 0)
        {
            P2_timeLeft = 0;
            P2_Play = false;
            P2_Ready = false;
            P2_CountDown = false;
            P2_TimeIsUp = true;
            //P2_ATKman.Casting = true;
        }

    }
    IEnumerator P1_ReadyUp()
    {

        P1_PromptText.color = Default;
        P1_PromptText.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        //PromptText.text = "Please Input Command to Start";
        P1_timeLeft = 3;
        P1_Ready = true;
        //yield return new WaitForSeconds(1f);
        //P1_Manager.LeftMan.Casted = false;
        //P1_Manager.RightMan.Casted = false;
        P1.Left = false;
        P1.Right = false;
        P1.RightAtk = false;
        P1.RightDef = false;
        P1.LeftAtk = false;
        P1.LeftDef = false;
        P1.TotaledUp = false;
        P1_Live = true;
        P1_ATKman.TurnOver = false;
        Debug.Log("Ready!");
        StopCoroutine(P1_ReadyUp());
    }

    IEnumerator P2_ReadyUp()
    {

        
        P2_PromptText.color = Default;
        P2_PromptText.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        //PromptText.text = "Please Input Command to Start";
        P2_timeLeft = 3;
        P2_Ready = true;
        //yield return new WaitForSeconds(1f);
        //P1_Manager.LeftMan.Casted = false;
        //P1_Manager.RightMan.Casted = false;
        P2.Left = false;
        P2.Right = false;
        P2.RightAtk = false;
        P2.RightDef = false;
        P2.LeftAtk = false;
        P2.LeftDef = false;
        P2.TotaledUp = false;
        P2_Live = true;
        P2_ATKman.TurnOver = false;
        StopCoroutine(P2_ReadyUp());
    }

    IEnumerator P1_SpellText()
    {
        if (P1.Right == true && P1.Left == true)
        {
            P1_AttackTextPrompt = P1_AttackTextL + " & " + P1_AttackTextR;
        }
        if (P1.Right == true && P1.Left == false)
        {
            P1_AttackTextPrompt = P1_AttackTextR;
        }
        if (P1.Left == true && P1.Right == false)
        {
            P1_AttackTextPrompt = P1_AttackTextL;
        }
        yield return new WaitForEndOfFrame();
        P1_PromptText.text = P1_AttackTextPrompt;
        //PromptText.text = "Casting";
        yield return new WaitForSeconds(5f);

        
    }
    IEnumerator P2_SpellText()
    {
        if (P2.Right == true && P2.Left == true)
        {
            P2_AttackTextPrompt = P1_AttackTextL + " & " + P1_AttackTextR;
        }
        if (P2.Right == true && P2.Left == false)
        {
            P2_AttackTextPrompt = P2_AttackTextR;
        }
        if (P2.Left == true && P2.Right == false)
        {
            P2_AttackTextPrompt = P2_AttackTextL;
        }
        yield return new WaitForEndOfFrame();
        P2_PromptText.text = P2_AttackTextPrompt;
        //PromptText.text = "Casting";
        yield return new WaitForSeconds(5f);

    }
}
