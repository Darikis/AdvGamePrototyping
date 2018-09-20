using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanal : MonoBehaviour {

    public GameObject PP;
    public TimerManager TM;
    public ImageMaster IM;
    public float Total;
    public float RPowerLvl;
    public float LPowerLvl;
    public float Vote01;
    public float Vote02;
    public float Vote03;
    public float Vote04;
    public float HealthTotal;
    public Image P1_btn;
    public Image P2_btn;
    public Image P3_btn;
    public Image P4_btn;
    public Image P5_btn;
    public Vector3 Pos;
    public bool AmP1;
    public bool AmP2;
    public bool InputReady = false;
    public bool Pressed = false;
    public bool btn1;
    public bool btn2;
    public bool btn3;
    public bool btn4;
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
    private void Awake()
    {
        
    }
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
        /*if (Total >= 1)
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
        }*/

        foreach (CtrlScheme ctrl in ListOfPlayers)
        {
            
            if (Pressed == false)
            {
                ctrl.ReadyToAct = true;
                ctrl.Green = false;
                ctrl.Yellow = false;
                ctrl.Grey = true;
            }
            if (ctrl.Grey == true)
            {
                if (P1_btn != null)
                {
                    P1_btn.color = IM.Default;
                    P1_btn = null;
                }
                if (P2_btn != null)
                {
                    P2_btn.color = IM.Default;
                    P2_btn = null;
                }
                if (P3_btn != null)
                {
                    P3_btn.color = IM.Default;
                    P3_btn = null;
                }
                if (P4_btn != null)
                {
                    P4_btn.color = IM.Default;
                    P4_btn = null;
                }
                if (P5_btn != null)
                {
                    P5_btn.color = IM.Default;
                    P5_btn = null;
                }
            }

            if (Input.GetKeyDown(ctrl.B1) && InputReady == true && ctrl.ReadyToAct == true)
            {
                
                //Image PressedButton = GameObject.Find("imgB1" + ctrl.ButtonSuffix + "1").GetComponent<Image>();
                //PressedButton.color = IM.Attackclr;
                //PressedButton.enabled = true;
                MoveForward();
                Pressed = true;
                btn1 = true;
                ctrl.Green = true;
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
                //GameObject.Find("imgB2" + ctrl.ButtonSuffix + "2").GetComponent<Image>().enabled = true;
                MoveRight();
                ctrl.Green = true;
                btn2 = true;
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
                //GameObject.Find("imgB3" + ctrl.ButtonSuffix + "3").GetComponent<Image>().enabled = true;
                MoveLeft();
                ctrl.Yellow = true;
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
                //GameObject.Find("imgB4" + ctrl.ButtonSuffix + "4").GetComponent<Image>().enabled = true;
                MoveBackward();
                ctrl.Yellow = true;
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
            if (CanTotal == true)
            {
                btn1 = false;
                btn2 = false;
                btn3 = false;
                btn4 = false;
            }
            if (btn1 == false && btn2 == false && btn3 == false && btn4 == false)
            {
                ctrl.ReadyToAct = true;
                ctrl.Green = false;
                ctrl.Yellow = false;
                ctrl.Grey = true;
            }
            if (ctrl.Grey == true)
            {
                if (P1_btn != null)
                {
                    P1_btn.color = IM.Default;
                    P1_btn = null;
                }
                if (P2_btn != null)
                {
                    P2_btn.color = IM.Default;
                    P2_btn = null;
                }
                if (P3_btn != null)
                {
                    P3_btn.color = IM.Default;
                    P3_btn = null;
                }
                if (P4_btn != null)
                {
                    P4_btn.color = IM.Default;
                    P4_btn = null;
                }
                if (P5_btn != null)
                {
                    P5_btn.color = IM.Default;
                    P5_btn = null;
                }
            }
            if (Pressed == true)
            {
                ctrl.Grey = false;
                //GameObject PressedBtn = GameObject.Find("imgB1" + ctrl.ButtonSuffix + "1");
                //Image PressedButton = PressedBtn.GetComponent<Image>();
                //PressedButton.GetComponent<Image>().color = new Color32(IM.Attackclr);
                if (ctrl.Player1 == true && btn1 == true)
                {
                    
                    for (int i = 0; i < IM.P1Images.Count; i++)
                    {
                        if (IM.P1Images[i].name == "imgB1" + ctrl.ButtonSuffix + "_1" && P1_btn == null)
                        {
                            P1_btn = IM.P1Images[i];
                        }
                    }
                    if (ctrl.Green == true && P1_btn != null)
                    {
                        //PressedBtn.color;
                        P1_btn.GetComponent<Image>().color = IM.Attackclr;
                    }
                    if (ctrl.Yellow == true && P1_btn != null)
                    {
                        P1_btn.GetComponent<Image>().color = IM.Defendclr;
                    }
                }
                    //P1_btn = IM.P2Images.Where(obj => obj.name == "imgB1" + ctrl.ButtonSuffix + "_1").SingleOrDefault();
                    //Image PressedBtn = P1_btn;
                    //PressedBtn;
                    //P1_btn = GameObject.Find("imgB1" + ctrl.ButtonSuffix + "1").GetComponent<Image>();
                    //PressedButton.GetComponent<Image>();

            }
                /*if (ctrl.Player2 == true)
                {
                    for (int i = 0; i < IM.P2Images.Count; i++)
                    {
                        if (IM.P2Images[i].name == "imgB1" + ctrl.ButtonSuffix + "_1" && P2_btn == null)
                        {
                            P2_btn = IM.P2Images[i];
                        }
                    }
                    if (ctrl.Green == true)
                    {
                        P2_btn.color = IM.Attackclr;
                    }
                    if (ctrl.Yellow == true)
                    {
                        P2_btn.color = IM.Defendclr;
                    }
                }*/

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
        if (Vote02 > Vote04)
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
