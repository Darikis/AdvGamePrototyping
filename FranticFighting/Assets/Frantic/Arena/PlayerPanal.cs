using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanal : MonoBehaviour {

    public GameObject PP;
    public TimerManager TM;
    public float Total;
    public float RPowerLvl;
    public float LPowerLvl;
    public float Vote01;
    public float Vote02;
    public float Vote03;
    public float Vote04;
    public float HealthTotal;
    public Image im01;
    public Image im02;
    public Image im03;
    public Image im04;
    public Image im05;
    public Vector3 Pos;
    public bool AmP1;
    public bool AmP2;
    public bool InputReady = false;
    public bool Pressed = false;
    public bool Right;
    public bool Left;
    public bool RightAtk;
    public bool LeftAtk;
    public bool RightDef;
    public bool LeftDef;
    //public bool CanPause;
    public bool TotaledUp;
    public bool CanTotal;
    public Rigidbody rigi;
    //public TimerP TP;
    //public SpellManager Manager;
    public Players PlayerCtrl;
    public List<CtrlScheme> ListOfPlayers;

	// Use this for initialization
	void Start () {
        PP = gameObject;
        rigi = PP.GetComponent<Rigidbody>();
        TotaledUp = false;
        CanTotal = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (AmP1 == true)
        {
            if (TM.P1_timeLeft > 0 && TM.P1_Ready == true)
            {
                InputReady = true;
            }
            else
            {
                InputReady = false;
            }
            /*if (TM.P1_Ready == true && CanPause == true)
            {
                StartCoroutine(P1_Pause());
                CanPause = false;
            }*/
            if (TM.P1_timeLeft <= 0 && TotaledUp == false && CanTotal == true)
            {
                StartCoroutine(P1_TallyUp());
                CanTotal = false;
            }
        }
        if (AmP2 == true)
        {
            if (TM.P2_timeLeft > 0 && TM.P2_Ready == true)
            {
                InputReady = true;
            }
            else
            {
                InputReady = false;
            }
            /*if (TM.P2_Ready == true && CanPause == true)
            {
                StartCoroutine(P2_Pause());
            }*/
            if (TM.P2_timeLeft <= 0 && TotaledUp == false && CanTotal == true)
            {
                StartCoroutine(P2_TallyUp());
                CanTotal = false;
            }
        }


        Total = Vote01 + Vote02 + Vote03 + Vote04;
        if (Total >= 1)
        {
            im01.enabled = true;
        }
        if (Total >= 2)
        {
            im02.enabled = true;
        }
        if (Total >= 3)
        {
            im03.enabled = true;
        }
        if (Total >= 4)
        {
            im04.enabled = true;
        }
        if (Total >= 5)
        {
            im05.enabled = true;
        }
        if (Total == 0)
        {
            im01.enabled = false;
            im02.enabled = false;
            im03.enabled = false;
            im04.enabled = false;
            im05.enabled = false;
        }

        foreach (CtrlScheme ctrl in ListOfPlayers)
        {
            if (Pressed == false)
            {
                ctrl.ReadyToAct = true;
            }
            if (Input.GetKeyDown(ctrl.B1) && InputReady == true && ctrl.ReadyToAct == true)
            {

                MoveForward();
                Pressed = true;
                if (AmP1 == true)
                {
                    TM.P1_TallyTime = true;
                }
                if (AmP2 == true)
                {
                    TM.P2_TallyTime = true;
                }
                ctrl.ReadyToAct = false;
                //Debug.Log("BAD BAD BAD");
            }
            if (Input.GetKeyDown(ctrl.B2) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveRight();
                Pressed = true;
                if (AmP1 == true)
                {
                    TM.P1_TallyTime = true;
                }
                if (AmP2 == true)
                {
                    TM.P2_TallyTime = true;
                }
                ctrl.ReadyToAct = false;
            }
            if (Input.GetKeyDown(ctrl.B3) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveLeft();
                Pressed = true;
                if (AmP1 == true)
                {
                    TM.P1_TallyTime = true;
                }
                if (AmP2 == true)
                {
                    TM.P2_TallyTime = true;
                }
                ctrl.ReadyToAct = false;
            }
            if (Input.GetKeyDown(ctrl.B4) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveBackward();
                Pressed = true;
                if (AmP1 == true)
                {
                    TM.P1_TallyTime = true;
                }
                if (AmP2 == true)
                {
                    TM.P2_TallyTime = true;
                }
                ctrl.ReadyToAct = false;
            }
        }

    }
    void MoveForward()
    {
        //Zval = Zval + MoveVal;
        Vote01 = Vote01 + 1;
        //rigi.AddForce(Vector3.forward * RunSpeed, ForceMode.Impulse);
    }
    void MoveBackward()
    {
        //Zval = Zval - MoveVal;
        Vote04 = Vote04 + 1; 
        //rigi.AddForce(Vector3.back * RunSpeed, ForceMode.Impulse);
    }
    void MoveRight()
    {
        //Xval = Xval + MoveVal;
        Vote02 = Vote02 + 1;
        //rigi.AddForce(Vector3.right * RunSpeed, ForceMode.Impulse);
    }
    void MoveLeft()
    {
        //Xval = Xval - MoveVal;
        Vote03 = Vote03 + 1; 
        //rigi.AddForce(Vector3.left * RunSpeed, ForceMode.Impulse);
    }

    IEnumerator P1_Pause()
    { 
        Pressed = false;
        //TP.timeLeft = 3;
        yield return new WaitForEndOfFrame();
        Vote01 = 0;
        Vote02 = 0;
        Vote03 = 0;
        Vote04 = 0;
        Total = 0;
        //StopCoroutine(TallyUp());
        StopCoroutine(P1_Pause());
    }
    IEnumerator P2_Pause()
    {
        Pressed = false;
        //TP.timeLeft = 3;
        yield return new WaitForEndOfFrame();
        Vote01 = 0;
        Vote02 = 0;
        Vote03 = 0;
        Vote04 = 0;
        Total = 0;
        //StopCoroutine(TallyUp());
        StopCoroutine(P2_Pause());
    }

    IEnumerator P1_TallyUp()
    {
        
        if (Vote01 > Vote03)
        {
            //print("1 is bigga and equals " + Vote01);
            LPowerLvl = Vote01;
            LeftAtk = true;
            Left = true;
            TM.P1_AttackTextL = "Level " + LPowerLvl + " Left Attack!";
        }
        if (Vote02 >  Vote04)
        {
            //print("2 is bigga and equals " + Vote02);
            RPowerLvl = Vote02;
            RightAtk = true;
            Right = true;
            TM.P1_AttackTextR = "Level " + RPowerLvl + " Right Attack!";
        }
        if (Vote03 > Vote01)
        {
            //print("3 is bigga and equals " + Vote03);
            LPowerLvl = Vote03;
            LeftDef = true;
            Left = true;
            TM.P1_AttackTextL = "Level " + LPowerLvl + " Left Defense!";
        }
        if (Vote04 > Vote02)
        {
            //print("4 is bigga and equals " + Vote04);
            RPowerLvl = Vote04;
            RightDef = true;
            Right = true;
            TM.P1_AttackTextR = "Level " + RPowerLvl + " Right Defense!";
        }
        
        yield return new WaitForSeconds(1);
        Debug.Log("Tally");
        TotaledUp = true;
        StartCoroutine(P1_Pause());
        StopCoroutine(P1_TallyUp());
        
    }
    IEnumerator P2_TallyUp()
    {
        
        if (Vote01 > Vote03)
        {
            //print("1 is bigga and equals " + Vote01);
            LPowerLvl = Vote01;
            LeftAtk = true;
            Left = true;
            TM.P2_AttackTextL = "Level " + LPowerLvl + " Left Attack!";
        }
        if (Vote02 >  Vote04)
        {
            //print("2 is bigga and equals " + Vote02);
            RPowerLvl = Vote02;
            RightAtk = true;
            Right = true;
            TM.P2_AttackTextR = "Level " + RPowerLvl + " Right Attack!";
        }
        if (Vote03 > Vote01)
        {
            //print("3 is bigga and equals " + Vote03);
            LPowerLvl = Vote03;
            LeftDef = true;
            Left = true;
            TM.P2_AttackTextL = "Level " + LPowerLvl + " Left Defense!";
        }
        if (Vote04 > Vote02)
        {
            //print("4 is bigga and equals " + Vote04);
            RPowerLvl = Vote04;
            RightDef = true;
            Right = true;
            TM.P2_AttackTextR = "Level " + RPowerLvl + " Right Defense!";
        }
        
        yield return new WaitForSeconds(1);
        Debug.Log("Tally");
        TotaledUp = true;
        StartCoroutine(P2_Pause());
        StopCoroutine(P2_TallyUp());
        
    }

    

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Something Hit Me!");
        }
        
    }*/

}
