using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {

    public PlayerPanal PP;
    //public TimerP TP;
    public AttackManager Manager;
    public Manager Master;
    public bool RightManager;
    public bool LeftManager;
    //public bool Casting;
    public bool Casted;
    //public bool TurnOver;
    public float SpellLvlR;
    public float SpellLvlL;
    public GameObject Spell01Transform;
    public GameObject Spell02transform;
    public GameObject AttackSpell;
    public GameObject DefenseSpell;
    public Animator Anim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if( RightManager == true)
        {
            if (Manager.Casting == true && Casted == false && PP.RightAtk == true && Master.Go == true)
            {
                SpellLvlR = PP.RPowerLvl;
                Manager.Casted = true;
                AttackSpell = Instantiate(Spell01Transform, Manager.RightMan.transform.position, Quaternion.identity);
                AttackSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlR;
                AttackSpell.transform.parent = Manager.RightMan.gameObject.transform;
                //StartCoroutine(CastingRightSide());
                StartCoroutine(CommenceAttack());
                Casted = true;
            }

            if (Manager.Casting == true && Casted == false && PP.RightDef == true && Master.Go == true)
            {
                SpellLvlR = PP.RPowerLvl;
                Manager.Casted = true;
                DefenseSpell = Instantiate(Spell02transform, Manager.RightMan.transform.position, Quaternion.identity);
                DefenseSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlR;
                DefenseSpell.transform.parent = Manager.RightMan.gameObject.transform;
                //StartCoroutine(CastingRightSide());
                StartCoroutine(CommenceAttack());
                Casted = true;
            }
        }
        if (LeftManager == true)
        {
            if (Manager.Casting == true && Casted == false && PP.LeftAtk == true && Master.Go == true)
            {
                SpellLvlL = PP.LPowerLvl;
                Manager.Casted = true;
                AttackSpell = Instantiate(Spell01Transform, Manager.LeftMan.transform.position, Quaternion.identity);
                AttackSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlL;
                AttackSpell.transform.parent = Manager.LeftMan.gameObject.transform;
                //StartCoroutine(CastingLeftSide());
                StartCoroutine(CommenceAttack());
                Casted = true;
            }

            if (Manager.Casting == true && Casted == false && PP.LeftDef == true && Master.Go == true)
            {
                SpellLvlL = PP.LPowerLvl;
                Manager.Casted = true;
                DefenseSpell = Instantiate(Spell02transform, Manager.LeftMan.transform.position, Quaternion.identity);
                DefenseSpell.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvlL;
                DefenseSpell.transform.parent = Manager.LeftMan.gameObject.transform;
                //StartCoroutine(CastingLeftSide());
                StartCoroutine(CommenceAttack());
                Casted = true;
            }
        }



    }

    IEnumerator CommenceAttack()
    {
        Anim.SetBool("IsAttacking?", true);
        yield return new WaitForSeconds(3.5f);
        Anim.SetBool("IsAttacking?", false);
        Master.P1_TakeDamage = true;
        Master.P2_TakeDamage = true;
        if (PP.Left == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        if (PP.Right == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        Manager.TurnOver = true;
        Manager.Casted = true;
        PP.TotaledUp = false;
        Master.Go = false;
        StopCoroutine(CommenceAttack());
    }
    /*IEnumerator CastingRightSide()
    {
        Anim.SetBool("IsAttacking?", true);
        yield return new WaitForSeconds(3.5f);
        Anim.SetBool("IsAttacking?", false);
        if (PP.Left == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        if (PP.Right == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        Manager.TurnOver = true;
        Manager.Casted = true;
        Master.Go = false;
        PP.TotaledUp = false;
        StopCoroutine(CastingRightSide());
    }
    IEnumerator CastingLeftSide()
    {
        Anim.SetBool("IsAttacking?", true);
        yield return new WaitForSeconds(3.5f);
        Anim.SetBool("IsAttacking?", false);
        if (PP.Left == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        if (PP.Right == true)
        {
            GameObject.Destroy(AttackSpell);
            AttackSpell = null;
            GameObject.Destroy(DefenseSpell);
            DefenseSpell = null;
        }
        Manager.TurnOver = true;
        Manager.Casted = true;
        Master.Go = false;
        PP.TotaledUp = false;
        StopCoroutine(CastingLeftSide());
    }*/
}
