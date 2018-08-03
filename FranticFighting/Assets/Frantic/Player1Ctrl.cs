using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ctrl : MonoBehaviour {

    public GameObject Player;
    public float RunSpeed;
    public float MoveVal;
    public float Zval;
    public float Xval;
    public Vector3 Pos;
    public bool InputReady;
    public Rigidbody rigi;
    public Timer Timer;
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

        if (Timer.timeLeft > 0)
        {
            InputReady = true;
        }
        else
        {
            InputReady = false;
        }
        
        if (InputReady == false)
        {
            Timer.timeLeft = 0;
            Player.transform.position = Pos;
            StartCoroutine(Pause());
        }
        
        foreach (CtrlScheme ctrl in ListOfPlayers)
        {
            if (Input.GetKeyDown(ctrl.B1))
            {
                MoveForward();
            }
            if (Input.GetKeyDown(ctrl.B2))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(ctrl.B3))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(ctrl.B4))
            {
                MoveBackward();
            }
        }
    }
    void MoveForward()
    {
        Zval = Zval + MoveVal;
        //rigi.AddForce(Vector3.forward * RunSpeed, ForceMode.Impulse);
        
    }
    void MoveBackward()
    {
        Zval = Zval - MoveVal;
        //rigi.AddForce(Vector3.back * RunSpeed, ForceMode.Impulse);
        
    }
    void MoveRight()
    {
        Xval = Xval + MoveVal;
        //rigi.AddForce(Vector3.right * RunSpeed, ForceMode.Impulse);
        
    }
    void MoveLeft()
    {
        Xval = Xval - MoveVal;
        //rigi.AddForce(Vector3.left * RunSpeed, ForceMode.Impulse);
        
    }
    IEnumerator Pause()
    {
        
        yield return new WaitForSeconds(1f);
        Timer.timeLeft = 1;
        Timer.CountDown = true;
        StopCoroutine(Pause());
    }
}
