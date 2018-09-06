using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{


    public PlayerPanal PP;
    public TimerP TP;
    public bool OwnerIsP1;
    public bool OwnerIsP2;
    public float ATKlvlL;
    public float DEFlvlL;
    public float ATKlvlR;
    public float DEFlvlR;
    public SpellManager LeftMan;
    public SpellManager RightMan;
    public bool Casting;
    public bool Casted;
    public bool TurnOver;
    public Manager Master;
    //public AttackManager P1Man;
    //public AttackManager P2Man;
    //public bool Attacking;
    public bool AttackingR;
    public bool AttackingL;
    //public bool Defending;
    public bool DefendingR;
    public bool DefendingL;
    //public bool TakeDamage;




    // Use this for initialization
    void Start()
    {

        //Master.P1_ATKman = P1Man;
        //Master.P2_ATKman = P2Man;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
