using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{


    public PlayerPanal Player1;
    public PlayerPanal Player2;
    public TimerP P1_TP;
    public TimerP P2_TP;
    public float P1_CurrentHP;
    public float P2_CurrentHP;
    public float P1_DamageL;
    public float P1_DamageR;
    public float P2_DamageL;
    public float P2_DamageR;
    public bool P1_TakeDamage;
    public bool P2_TakeDamage;
    public bool P1_TakeDamageR;
    public bool P1_TakeDamageL;
    public bool P2_TakeDamageR;
    public bool P2_TakeDamageL;
    public bool Go;
    public bool CanTakeDmg;
    public Slider P1_HealthBar;
    public Slider P2_HealthBar;
    public AttackManager P1_ATKman;
    public AttackManager P2_ATKman;


    // Use this for initialization
    void Start()
    {
        P1_CurrentHP = 10;
        P2_CurrentHP = 10;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (P1_ATKman.LeftMan.OnAttack == true)
        {
            Attack();
        }
        if (P2_ATKman.LeftMan.OnAttack == true)
        {
            Attack();
        }
        if (P1_ATKman.RightMan.OnAttack == true)
        {
            Attack();
        }*/
        if (Player1.TotaledUp == true && Player2.TotaledUp == true)
        {
            Go = true;
        }
        if (Go == false)
        {
            //P1_TakeDamage = false;
            //P2_TakeDamage = false;
            P1_ATKman.ATKlvlR = 0;
            P1_ATKman.ATKlvlL = 0;
            P2_ATKman.ATKlvlR = 0;
            P2_ATKman.ATKlvlL = 0;

        }


        /*if (P1_ATKman.ATKlvlR < P2_ATKman.ATKlvlL)
        {
            P1_TakeDamageR = true;
        }
        if (P1_ATKman.ATKlvlR > P2_ATKman.ATKlvlL)
        {
            P2_TakeDamageL = true;
        }
        if (P1_ATKman.ATKlvlL > P2_ATKman.ATKlvlR)
        {
            P2_TakeDamageR = true;
        }
        if (P1_ATKman.ATKlvlL < P2_ATKman.ATKlvlR)
        {
            P1_TakeDamageL = true;
        }*/

        /*
        if (P1_ATKman.DEFlvlR < P2_ATKman.ATKlvlL)
        {
            P1_TakeDamageR = true;
        }
        if (P1_ATKman.DEFlvlR >= P2_ATKman.ATKlvlL)
        {
            P1_TakeDamageR = false;
        }
        if (P1_ATKman.DEFlvlL < P2_ATKman.ATKlvlR)
        {
            P1_TakeDamageL = true;
        }
        if (P1_ATKman.DEFlvlL >= P2_ATKman.ATKlvlR)
        {
            P1_TakeDamageL = false;
        }
        if (P1_ATKman.ATKlvlR <= P2_ATKman.DEFlvlL)
        {
            P2_TakeDamageL = false;
        }
        if (P1_ATKman.ATKlvlR > P2_ATKman.DEFlvlL)
        {
            P2_TakeDamageL = true;
        }
        if (P1_ATKman.ATKlvlL <= P2_ATKman.DEFlvlR)
        {
            P2_TakeDamageR = false;
        }
        if (P1_ATKman.ATKlvlL > P2_ATKman.DEFlvlR)
        {
            P2_TakeDamageR = true;
        }

        if (P2_ATKman.ATKlvlL == 0)
        {
            P1_TakeDamageR = false;
        }
        if (P2_ATKman.ATKlvlR == 0)
        {
            P1_TakeDamageL = false;
        }
        if (P2_ATKman.ATKlvlL == 0)
        {
            P1_TakeDamageR = false;
        }
        if (P2_ATKman.ATKlvlR == 0)
        {
            P1_TakeDamageL = false;
        }*/






        if (P2_ATKman.ATKlvlL > 0)
        {
           
            if (P1_ATKman.ATKlvlR < P2_ATKman.ATKlvlL)
            {
                P1_TakeDamageR = true;
            }
            
        }
        if(P1_TakeDamageR == true)
        {
            if (P1_ATKman.DEFlvlR < P2_ATKman.ATKlvlL)
            {
                P1_TakeDamage = true;
                P1_TakeDamageR = true;
            }
            if (P1_ATKman.DEFlvlR >= P2_ATKman.ATKlvlL)
            {
                P1_TakeDamage = true;
                P1_TakeDamageR = false;
            }
        }

        if (P2_ATKman.ATKlvlR > 0)
        {
            
            if (P1_ATKman.ATKlvlL < P2_ATKman.ATKlvlR)
            {
                P1_TakeDamageL = true;
            }
            
        }
        if(P1_TakeDamageL == true)
        {
            if (P1_ATKman.DEFlvlL < P2_ATKman.ATKlvlR)
            {
                P1_TakeDamage = true;
                P1_TakeDamageL = true;
            }
            if (P1_ATKman.DEFlvlL >= P2_ATKman.ATKlvlR)
            {
                P1_TakeDamage = true;
                P1_TakeDamageL = false;
            }
        }
        

        if (P1_ATKman.ATKlvlR > 0)
        {
            
            if (P1_ATKman.ATKlvlR > P2_ATKman.ATKlvlL)
            {
                P2_TakeDamageL = true;
            }
            
        }
        if(P2_TakeDamageL == true)
        {
            if (P1_ATKman.ATKlvlR > P2_ATKman.DEFlvlL)
            {
                P2_TakeDamage = true;
                P2_TakeDamageL = true;
            }
            if (P1_ATKman.ATKlvlR <= P2_ATKman.DEFlvlL)
            {
                P2_TakeDamage = true;
                P2_TakeDamageL = false;
            }
        }
        

        if (P1_ATKman.ATKlvlL > 0)
        {
            
            if (P1_ATKman.ATKlvlL > P2_ATKman.ATKlvlR)
            {
                P2_TakeDamageR = true;
            }
            
            
        }
        if(P2_TakeDamageR == true)
        {
            if (P1_ATKman.ATKlvlL > P2_ATKman.DEFlvlR)
            {
                P2_TakeDamage = true;
                P2_TakeDamageR = true;
            }
            if (P1_ATKman.ATKlvlL <= P2_ATKman.DEFlvlR)
            {
                P2_TakeDamage = true;
                P2_TakeDamageR = false;
            }
        }
        

        




        P1_HealthBar.value = P1_CurrentHP;
        P2_HealthBar.value = P2_CurrentHP;

        if (Player1.LPowerLvl > Player1.RPowerLvl)
        {
            P1_DamageL = Player1.LPowerLvl;
        }
        if (Player1.RPowerLvl > Player1.LPowerLvl)
        {
            P1_DamageR = Player1.RPowerLvl;
        }
        if (Player2.LPowerLvl > Player2.RPowerLvl)
        {
            P2_DamageL = Player2.LPowerLvl;
        }
        if (Player2.RPowerLvl > Player2.LPowerLvl)
        {
            P2_DamageR = Player2.RPowerLvl;
        }





        if (P1_TakeDamageL == true && P1_TakeDamage == true && Go == true)
        {
            P1_CurrentHP = P1_CurrentHP - P2_DamageR;
            //P1_TakeDamage = false;
            Go = false;
        }
        if (P2_TakeDamageL == true && P2_TakeDamage == true && Go == true)
        {
            P2_CurrentHP = P2_CurrentHP - P1_DamageR;
            //P2_TakeDamage = false;
            Go = false;
        }
        if (P1_TakeDamageR == true && P1_TakeDamage == true && Go == true)
        {
            P1_CurrentHP = P1_CurrentHP - P2_DamageL;
            Debug.Log("KaBOOOM");
            //P1_TakeDamage = false;
            Go = false;
        }
        if (P2_TakeDamageR == true && P2_TakeDamage == true && Go == true)
        {
            P2_CurrentHP = P2_CurrentHP - P1_DamageL;
            //P2_TakeDamage = false;
            Go = false;
        }
    }
    
}
    
