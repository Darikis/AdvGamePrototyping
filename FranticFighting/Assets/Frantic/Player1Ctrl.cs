using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ctrl : MonoBehaviour {

    public GameObject Player;
    public float RunSpeed;
    public float MoveVal;
    public float Zval;
    public float Xval;
    public int Vote01;
    public int Vote02;
    public int Vote03;
    public int Vote04;
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

	}
	
	// Update is called once per frame
	void Update () {

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
            Player.transform.position = Pos;
            StartCoroutine(Pause());
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
        Vote02 = Vote02 + 1;
        //rigi.AddForce(Vector3.back * RunSpeed, ForceMode.Impulse);
    }
    void MoveRight()
    {
        Xval = Xval + MoveVal;
        Vote03 = Vote03 + 1;
        //rigi.AddForce(Vector3.right * RunSpeed, ForceMode.Impulse);
    }
    void MoveLeft()
    {
        Xval = Xval - MoveVal;
        Vote04 = Vote04 + 1;
        //rigi.AddForce(Vector3.left * RunSpeed, ForceMode.Impulse);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        Timer.timeLeft = 2;
        Timer.Play = false;
        Pressed = false;
        StopCoroutine(Pause());
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Something Hit Me!");
    }

}
