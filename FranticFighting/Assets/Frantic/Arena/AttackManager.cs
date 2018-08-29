using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {


    public PlayerPanal PP;
    public TimerP TP;
    public bool Casting;
    public bool Casted;
    public float SpellLvl;
    ///public MasterParticleCtrl Part;
    public GameObject Spell01Transform;
    public GameObject Spell02transform;
    public GameObject Action;
    public Animator Anim;
    //public GameObject Owner;
    //public string OwnerTag;
    
    


	// Use this for initialization
	void Start () {
        //Owner = GameObject.FindGameObjectWithTag("Player1");
        //Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Casting == true && Casted == false)
        {
            SpellLvl = PP.RPowerLvl;
            Action = Instantiate(Spell01Transform, transform.position, Quaternion.identity);
            Action.GetComponent<MasterParticleCtrl>().Partlvl = SpellLvl;
            Action.transform.parent = gameObject.transform;
            StartCoroutine(Attack());
            Casted = true;

            
        }

        /*if (Input.GetKey(KeyCode.Space) && TP.timeLeft <= 0 && Casting == true && Casted == false)
        {
            Instantiate(SpellTransform, transform.position, Quaternion.identity);
            Casted = true;
        }*/
	}
    IEnumerator Attack()
    {
        
        
        
        Anim.SetBool("IsAttacking?", true);
        //Anim.SetTrigger("Attacking");
        yield return new WaitForSeconds(3.5f);
        //Anim.Play("PlasmaBall");

        //yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length + Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Anim.SetBool("IsAttacking?", false);
        GameObject.Destroy(Action);
        StopCoroutine(Attack());


    }
}
