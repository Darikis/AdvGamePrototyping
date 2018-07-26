using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Ctrl : MonoBehaviour {

    public GameObject Player;
    public float RunSpeed;
    public Rigidbody rigi;

	// Use this for initialization
	void Start () {
        Player = gameObject;
        rigi = Player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
        {
            rigi.AddForce(Vector3.forward * RunSpeed, ForceMode.Impulse);
        }
	}
}
