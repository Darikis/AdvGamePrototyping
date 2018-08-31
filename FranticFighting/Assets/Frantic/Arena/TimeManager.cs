using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public float timeLeft = 2;
    public PlayerPanal P1;
    public PlayerPanal P2;
    public Text CountTextP1;
    public Text CountTextP2;
    public Manager Master;
    public AttackManager Manager;
    public Text PromptTextP1;
    public Text PromptTextP2;
    public bool CountDown = false;
    public bool Ready = false;
    public bool Play = false;
    public bool Live = false;
    public Color Default = new Color(0f, 250 / 255f, 255 / 255f);
    public Color Action = new Color(255 / 255f, 240 / 255f, 0f);

    // Use this for initialization
    void Start()
    {
        P1 = Master.Player1;
        P2 = Master.Player2;
    }

    // Update is called once per frame
    void Update()
    {

        CountTextP1.text = "TimeLeft: " + timeLeft.ToString();
        CountTextP2.text = "TimeLeft: " + timeLeft.ToString();

        if (Ready == false && Live == true && Manager.Casting == true && Manager.Casted == true)
        {
            StartCoroutine(Spell());
        }
        if (Ready == false && Live == true && Manager.Casting == false && Manager.TurnOver == true)
        {
            StopCoroutine(Spell());
            //PromptText.text = "Get Ready!";
            StartCoroutine(ReadyUp());
        }
        if (Ready == true && timeLeft > 0 && Manager.TurnOver == false)
        {
            PromptTextP1.color = Action;
            PromptTextP2.color = Action;
            PromptTextP1.text = "Please Input Command to Start";
            PromptTextP2.text = "Please Input Command to Start";
            Play = true;
        }
        if (Play == true && Master.Player1.Pressed == true)
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
    }
    IEnumerator ReadyUp()
    {
        Debug.Log("Ready!");
        PromptTextP1.color = Default;
        PromptTextP1.text = "Get Ready!";
        PromptTextP2.color = Default;
        PromptTextP2.text = "Get Ready!";
        yield return new WaitForSeconds(1f);
        //PromptText.text = "Please Input Command to Start";
        timeLeft = 2;
        //yield return new WaitForSeconds(1f);
        Ready = true;
        Live = true;
        Manager.TurnOver = false;
        Manager.Casted = false;
        Manager.LeftMan.Casted = false;
        Manager.RightMan.Casted = false;
        P1.Left = false;
        P1.Right = false;
        P1.RightAtk = false;
        P1.RightDef = false;
        P1.LeftAtk = false;
        P1.LeftDef = false;
        P2.Left = false;
        P2.Right = false;
        P2.RightAtk = false;
        P2.RightDef = false;
        P2.LeftAtk = false;
        P2.LeftDef = false;
        StopCoroutine(ReadyUp());
    }
    
    IEnumerator Spell()
    {
        Debug.Log("KaBOOOM");
        PromptTextP1.text = P1.AttackTextPrompt;
        PromptTextP2.text = P2.AttackTextPrompt;
        //PromptText.text = "Casting";
        yield return new WaitForSecondsRealtime(3f);
        Manager.Casting = false;
    }
}

    

