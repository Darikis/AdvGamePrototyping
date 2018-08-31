using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {


    public PlayerPanal Player1;
    public PlayerPanal Player2;
    public TimerP P1_TP;
    public TimerP P2_TP;
    public float P1_CurrentHP;
    public float P2_CurrentHP;
    public float P1_Damage;
    public float P2_Damage;
    public bool P1_TakeDamage;
    public bool P2_TakeDamage;
    public bool Go;
    public bool CanTakeDmg;
    public Slider P1_HealthBar;
    public Slider P2_HealthBar;
    

    // Use this for initialization
    void Start () {
        P1_CurrentHP = 10;
        P2_CurrentHP = 10;

        
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1.TotaledUp == true && Player2.TotaledUp == true)
        {
            Go = true;
        }
        P1_HealthBar.value = P1_CurrentHP;
        P2_HealthBar.value = P2_CurrentHP;

        if (Player1.LPowerLvl > Player1.RPowerLvl)
        {
            P1_Damage = Player1.LPowerLvl;
        }
        if (Player1.RPowerLvl > Player1.LPowerLvl)
        {
            P1_Damage = Player1.RPowerLvl;
        }
        if (Player2.LPowerLvl > Player2.RPowerLvl)
        {
            P2_Damage = Player2.LPowerLvl;
        }
        if (Player2.RPowerLvl > Player2.LPowerLvl)
        {
            P2_Damage = Player2.RPowerLvl;
        }

        if (P1_TakeDamage == true)
        {
            P1_CurrentHP = P1_CurrentHP - P2_Damage;
            P1_TakeDamage = false;
        }
        if (P2_TakeDamage == true)
        {
            P2_CurrentHP = P2_CurrentHP - P1_Damage;
            P2_TakeDamage = false;
        }

	}
}
