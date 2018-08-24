using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {


    public PlayerPanal PP;
    public TimerP TP;
    public bool Casting;
    public bool Casted;
    ///public MasterParticleCtrl Part;
    public GameObject SpellTransform;
    
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (TP.timeLeft <= 0 && Casting == true && Casted == false)
        {
            

            Instantiate(SpellTransform, transform.position, Quaternion.identity);
            Casted = true;
            
        }

        if (Input.GetKey(KeyCode.Space) && TP.timeLeft <= 0 && Casting == true && Casted == false)
        {
            Instantiate(SpellTransform, transform.position, Quaternion.identity);
            Casted = true;
        }
	}
}
