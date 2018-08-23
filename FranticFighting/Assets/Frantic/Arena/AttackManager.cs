using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {


    public PlayerPanal PP;
    public TimerP TP;
    public bool Casted = false;
    public MasterParticleCtrl Part;
    //public Transform SpellTransform;
    
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (TP.Ready == false)
        {
            Casted = true;
        }


        if (Casted == true)
        {
            PP.RPowerLvl = Part.Partlvl;
            GameObject Spell = (GameObject)Instantiate(Resources.Load("PS_Orb"));
            Casted = false;
        }
        if (Input.GetKey("Space"))
        {
            Casted = false;
        }
	}
}
