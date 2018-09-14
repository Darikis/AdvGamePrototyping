using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{


    public PlayerPanal Player1;
    public PlayerPanal Player2;
    public TimerManager TM;
    public float P1_CurrentHP;
    public float P2_CurrentHP;
    public float P1_DamageL;
    public float P1_DamageR;
    public float P2_DamageL;
    public float P2_DamageR;
    public float P1_GuardL;
    public float P1_GuardR;
    public float P2_GuardL;
    public float P2_GuardR;
    public bool P1_TakeDamage;
    public bool P2_TakeDamage;
    public bool P1_TakeDamageR;
    public bool P1_TakeDamageL;
    public bool P2_TakeDamageR;
    public bool P2_TakeDamageL;
    public bool Go;
    public bool NewTurn;
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
        
        if (P1_ATKman.TurnOver == true && P2_ATKman.TurnOver == true)
        {
            NewTurn = true;
            Go = false;
        }
        if (P1_ATKman.TurnOver == false && P2_ATKman.TurnOver == false)
        {
            NewTurn = false;
        }
        if (Go == false)
        {
            P1_TakeDamage = false;
            P2_TakeDamage = false;
            P1_ATKman.ATKlvlR = 0;
            P1_ATKman.ATKlvlL = 0;
            P2_ATKman.ATKlvlR = 0;
            P2_ATKman.ATKlvlL = 0;
            P1_DamageL = 0;
            P1_DamageR = 0;
            P2_DamageL = 0;
            P2_DamageR = 0;
            P1_ATKman.LeftMan.Casted = false;
            P1_ATKman.RightMan.Casted = false;
            P2_ATKman.LeftMan.Casted = false;
            P2_ATKman.RightMan.Casted = false;
            TM.ATKphase = false;


        }





        //DO P1 OR P2 TAKE DAMAGE
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
                //P1_TakeDamage = true;
                P1_TakeDamageR = true;
            }
            if (P1_ATKman.DEFlvlR >= P2_ATKman.ATKlvlL)
            {
                //P1_TakeDamage = true;
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
                //P1_TakeDamage = true;
                P1_TakeDamageL = true;
            }
            if (P1_ATKman.DEFlvlL >= P2_ATKman.ATKlvlR)
            {
                //P1_TakeDamage = true;
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
                //P2_TakeDamage = true;
                P2_TakeDamageL = true;
            }
            if (P1_ATKman.ATKlvlR <= P2_ATKman.DEFlvlL)
            {
                //P2_TakeDamage = true;
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
                //P2_TakeDamage = true;
                P2_TakeDamageR = true;
            }
            if (P1_ATKman.ATKlvlL <= P2_ATKman.DEFlvlR)
            {
                //P2_TakeDamage = true;
                P2_TakeDamageR = false;
            }
        }
        

        




        P1_HealthBar.value = P1_CurrentHP;
        P2_HealthBar.value = P2_CurrentHP;
        //SET DAMAGE LEVELS P1
        if (P1_ATKman.ATKlvlL > P1_ATKman.DEFlvlL)
        {
            P1_DamageL = P1_ATKman.ATKlvlL;
        }
        if (P1_ATKman.ATKlvlL < P1_ATKman.DEFlvlL)
        {
            P1_DamageL = 0;
        }
        if (P1_ATKman.ATKlvlR > P1_ATKman.DEFlvlR)
        {
            P1_DamageR = P1_ATKman.ATKlvlR;
        }
        if (P1_ATKman.ATKlvlR < P1_ATKman.DEFlvlR)
        {
            P1_DamageR = 0;
        }
        //Set GUARD LEVELS P1
        if (P1_ATKman.ATKlvlL > P1_ATKman.DEFlvlL)
        {
            P1_GuardL = 0;
        }
        if (P1_ATKman.ATKlvlL < P1_ATKman.DEFlvlL)
        {
            P1_GuardL = P1_ATKman.DEFlvlL;
        }
        if (P1_ATKman.ATKlvlR > P1_ATKman.DEFlvlR)
        {
            P1_GuardR = 0;
        }
        if (P1_ATKman.ATKlvlR < P1_ATKman.DEFlvlR)
        {
            P1_GuardR = P1_ATKman.DEFlvlR;
        }


        //SET DAMAGE LEVELS P2
        if (P2_ATKman.ATKlvlL > P2_ATKman.DEFlvlL)
        {
            P2_DamageL = P2_ATKman.ATKlvlL;
        }
        if (P2_ATKman.ATKlvlL < P2_ATKman.DEFlvlL)
        {
            P2_DamageL = 0;
        }
        if (P2_ATKman.ATKlvlR > P2_ATKman.DEFlvlR)
        {
            P2_DamageR = P2_ATKman.ATKlvlR;
        }
        if (P2_ATKman.ATKlvlR < P2_ATKman.DEFlvlR)
        {
            P1_DamageR = 0;
        }
        //SET GUARD LEVELS P2
        if (P2_ATKman.ATKlvlL > P2_ATKman.DEFlvlL)
        {
            P2_GuardL = 0;
        }
        if (P2_ATKman.ATKlvlL < P2_ATKman.DEFlvlL)
        {
            P2_GuardL = P1_ATKman.DEFlvlL;
        }
        if (P2_ATKman.ATKlvlR > P2_ATKman.DEFlvlR)
        {
            P2_GuardR = 0;
        }
        if (P2_ATKman.ATKlvlR < P2_ATKman.DEFlvlR)
        {
            P2_GuardR = P2_ATKman.DEFlvlR;
        }



        if (P1_TakeDamageL == true && P1_TakeDamage == true )
        {
            P1_CurrentHP = P1_CurrentHP - P2_DamageR + P1_GuardL;
            Debug.Log("1");
            P1_TakeDamage = false;
            //Go = false;
        }
        if (P2_TakeDamageL == true && P2_TakeDamage == true )
        {
            P2_CurrentHP = P2_CurrentHP - P1_DamageR + P2_GuardL;
            Debug.Log("2");
            P2_TakeDamage = false;
            //Go = false;
        }
        if (P1_TakeDamageR == true && P1_TakeDamage == true )
        {
            P1_CurrentHP = P1_CurrentHP - P2_DamageL + P1_GuardR;
            Debug.Log("3");
            P1_TakeDamage = false;
            //Go = false;
        }
        if (P2_TakeDamageR == true && P2_TakeDamage == true )
        {
            P2_CurrentHP = P2_CurrentHP - P1_DamageL + P2_GuardL;
            Debug.Log("4");
            P2_TakeDamage = false;
            //Go = false;
        }
    }
    
}
    
