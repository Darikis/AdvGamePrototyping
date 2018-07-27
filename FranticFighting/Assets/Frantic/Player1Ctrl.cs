using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ctrl : MonoBehaviour {

    public GameObject Player;
    public float RunSpeed;
    public Rigidbody rigi;
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
	}
	
	// Update is called once per frame
	void Update () {

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
        rigi.AddForce(Vector3.forward * RunSpeed, ForceMode.Impulse);
    }
    void MoveBackward()
    {
        rigi.AddForce(Vector3.back * RunSpeed, ForceMode.Impulse);
    }
    void MoveRight()
    {
        rigi.AddForce(Vector3.right * RunSpeed, ForceMode.Impulse);
    }
    void MoveLeft()
    {
        rigi.AddForce(Vector3.left * RunSpeed, ForceMode.Impulse);
    }
}
