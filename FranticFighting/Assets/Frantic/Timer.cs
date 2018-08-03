using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timeLeft;
    public Player1Ctrl Player;
    public Text CountText;
    public bool CountDown = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        CountText.text = timeLeft.ToString();
        if (timeLeft > 0 && CountDown == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            
            Player.InputReady = false;
            CountDown = false;
        }
        
    }
    
}
