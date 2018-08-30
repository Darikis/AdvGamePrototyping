using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {


    public PlayerPanal P1;
    public PlayerPanal P2;
    public bool Go;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (P1.TotaledUp == true && P2.TotaledUp == true)
        {
            Go = true;
        }
	}
}
