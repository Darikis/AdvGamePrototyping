using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {


    public PlayerPanal PP;
    public TimerP TP;
    public SpellManager LeftMan;
    public SpellManager RightMan;
    public bool Casting;
    public bool Casted;
    public bool TurnOver;
    //public float SpellLvlR;
    //public float SpellLvlL;
    //public GameObject RightMan;
    //public GameObject LeftMan;
    //public GameObject Spell01Transform;
    //public GameObject Spell02transform;
    //public GameObject RightSpell;
    //public GameObject LeftSpell;
    //public Animator Anim;
    
    
    


	// Use this for initialization
	void Start () {
        //Owner = GameObject.FindGameObjectWithTag("Player1");
        //Anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        /*if (Casting == true && Casted == false)
        {
            SpellLvlR = PP.RPowerLvl;
            RightSpell = Instantiate(Spell01Transform, transform.position, Quaternion.identity);
            RightSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlR;
            RightSpell.transform.parent = gameObject.transform;
            StartCoroutine(Attack());
            Casted = true;
        }
        if (Casting == true && Casted == false)
        {
            SpellLvlL = PP.LPowerLvl;
            LeftSpell = Instantiate(Spell01Transform, transform.position, Quaternion.identity);
            LeftSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlL;
            LeftSpell.transform.parent = gameObject.transform;
            StartCoroutine(Attack());
            Casted = true;
        }*/

    }
    /*IEnumerator Attack()
    {
        
        
        
        Anim.SetBool("IsAttacking?", true);
        //Anim.SetTrigger("Attacking");
        yield return new WaitForSeconds(3.5f);
        //Anim.Play("PlasmaBall");

        //yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length + Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Anim.SetBool("IsAttacking?", false);
        if (PP.Left == true)
        {
            GameObject.Destroy(LeftMan.LeftSpell);
            LeftMan.LeftSpell = null;
        }
        if (PP.Right == true)
        {
            GameObject.Destroy(RightMan.RightSpell);
            RightMan.RightSpell = null;
        }
        //Casting = false;
        TurnOver = true;
        StopCoroutine(Attack());
    }*/
}
