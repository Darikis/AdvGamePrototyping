using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ctrl : MonoBehaviour {

    public GameObject Player;
    public float Total;
    public float MoveVal;
    private float Zval;
    private float Xval;
    /*public int[] VOTES;
    public enum Options
    {
        Vote1,
        Vote2,
        Vote3,
        Vote4,
        numEntries
    }*/
    public float Vote01;
    public float Vote02;
    public float Vote03;
    public float Vote04;
    public Vector3 Pos;
    public bool InputReady = false;
    public bool Pressed = false;
    public Rigidbody rigi;
    public Timer Timer;
    public Manager Mana;
    public Players PlayerCtrl;
    public List<CtrlScheme> ListOfPlayers;
    
  


    /*[System.Serializable]
    public class Players
    {
        public KeyCode Player1Forward;
        public KeyCode Player1Right;
        public KeyCode Player1Left;
        public KeyCode Player1Backward;
    }*/
    
    //public KeyCode Player1Forward;

	// Use this for initialization
	void Start () {
        Player = gameObject;
        rigi = Player.GetComponent<Rigidbody>();
        Pos = Player.transform.position;
        Zval = Pos.z;
        Xval = Pos.x;
        

        


        //Spot = Player.transform;
        //Spot.position = new Vector3(Xval, 1f, Zval);

    }
	
	// Update is called once per frame
	void Update () {

        /*VOTES = new int[(int)Options.numEntries];
        VOTES[(int)Options.Vote1] = Vote01;
        VOTES[(int)Options.Vote2] = Vote02;
        VOTES[(int)Options.Vote3] = Vote03;
        VOTES[(int)Options.Vote4] = Vote04;
        for (int i = 0, i< (int)Options.numEntries; i++)
        {
            if(Options[i]>)
        }*/
        Pos = new Vector3(Xval, 1, Zval);

        if (Timer.timeLeft > 0 && Timer.Ready == true)
        {
            InputReady = true;
        }
        else
        {
            InputReady = false;
        }
        
        if (Timer.timeLeft <= 0)
        {
            Mathf.Max(Vote01, Vote02, Vote03, Vote04);
            Player.transform.position = Pos;
            StartCoroutine(Pause());
            StartCoroutine(TallyUp());
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
                ctrl.ReadyToAct = false;
                //Debug.Log("BAD BAD BAD");
            }
            if (Input.GetKeyDown(ctrl.B2) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveRight();
                Pressed = true;
                ctrl.ReadyToAct = false;
                
            }
            if (Input.GetKeyDown(ctrl.B3) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveLeft();
                Pressed = true;
                ctrl.ReadyToAct = false;
                
            }
            if (Input.GetKeyDown(ctrl.B4) && InputReady == true && ctrl.ReadyToAct == true)
            {
                MoveBackward();
                Pressed = true;
                ctrl.ReadyToAct = false;
                
            }
        }
    }
    void MoveForward()
    {
        Zval = Zval + MoveVal;
        Vote01 = Vote01 + 1;
        
        //rigi.AddForce(Vector3.forward * RunSpeed, ForceMode.Impulse);
    }
    void MoveBackward()
    {
        Zval = Zval - MoveVal;
        Vote04 = Vote04 + 1; 
        //rigi.AddForce(Vector3.back * RunSpeed, ForceMode.Impulse);
    }
    void MoveRight()
    {
        Xval = Xval + MoveVal;
        Vote02 = Vote02 + 1;
        //rigi.AddForce(Vector3.right * RunSpeed, ForceMode.Impulse);
    }
    void MoveLeft()
    {
        Xval = Xval - MoveVal;
        Vote03 = Vote03 + 1; 
        //rigi.AddForce(Vector3.left * RunSpeed, ForceMode.Impulse);
    }

    IEnumerator Pause()
    { 
        Timer.Play = false;
        Pressed = false;
        Timer.timeLeft = 2;
        yield return new WaitForSeconds(1f);
        StopCoroutine(Pause());
    }

    IEnumerator TallyUp()
    {
        /*if (Vote01 > Vote02 && Vote01 > Vote03 && Vote01 > Vote04)
        {
            print("1 is bigga!!!");
        }
        if (Vote02 > Vote01 && Vote02 > Vote03 && Vote02 > Vote04)
        {
            print("2 is bigga!!!");
        }
        if (Vote03 > Vote02 && Vote03 > Vote01 && Vote03 > Vote04)
        {
            print("3 is bigga!!!");
        }
        if (Vote04 > Vote02 && Vote04 > Vote03 && Vote04 > Vote01)
        {
            print("4 is bigga!!!");
        }*/
        if (Vote01 > Vote04)
        {
            print("1 is bigga and equals " + Vote01);
        }
        if (Vote02 >  Vote03)
        {
            print("2 is bigga and equals " + Vote02);
        }
        if (Vote03 > Vote02)
        {
            print("3 is bigga and equals " + Vote03);
        }
        if (Vote04 > Vote01)
        {
            print("4 is bigga and equals " + Vote04);
        }
        yield return new WaitForEndOfFrame();
        Vote01 = 0;
        Vote02 = 0;
        Vote03 = 0;
        Vote04 = 0;
        StopCoroutine(TallyUp());
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Something Hit Me!");
        }
        
    }

}
