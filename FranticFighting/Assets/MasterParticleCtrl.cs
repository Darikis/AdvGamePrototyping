using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterParticleCtrl : MonoBehaviour {

    //public PlayerPanal PP;
    public ParticleSystem Part01;
    public ParticleSystem Part02;
    //public GameObject Owner;
    //public string OwnerName;
    public float Partlvl;
    
    public int Particle01;
    public int Particle02;
    public float MaxPart01;
    public float MaxPart02;
    public float Emission01;
    public float Emission02;
    public float EmRate01;
    public float EmRate02;
    public float Noise01;
    public float Noise02;
    public float NoiseStr01;
    public float NoiseStr02;



    public ParticleSystem.MainModule _Main01;
    public ParticleSystem.EmissionModule _Emission01;
    public ParticleSystem.NoiseModule _Noise01;

    public ParticleSystem.MainModule _Main02;
    public ParticleSystem.EmissionModule _Emission02;
    public ParticleSystem.NoiseModule _Noise02;
    // Use this for initialization
    
    void Start () {

        //PP = Player;
        
        _Main01 = Part01.main;
        _Emission01 = Part01.emission;
        _Noise01 = Part01.noise;

        _Main02 = Part02.main;
        _Emission02 = Part02.emission;
        _Noise02 = Part02.noise;

        Particle01 = _Main01.maxParticles;
        Emission01 = _Emission01.rateOverTimeMultiplier;
        Noise01 = _Noise01.strength.constant;
        Particle02 = _Main02.maxParticles;
        Emission02 = _Emission02.rateOverTimeMultiplier;
        Noise02 = _Noise02.strength.constant;



    }
	
	// Update is called once per frame
	void Update () {
        //Owner = GameObject.FindWithTag(OwnerName);
        //MaxPart01 = Partlvl * Particle01;
        //Partlvl = PP.RPowerLvl * 2;

        EmRate01 = Partlvl * Emission01;
        NoiseStr01 = Partlvl * Noise01;
        //MaxPart02 = Partlvl * Particle02;
        EmRate02 = Partlvl * Emission02;
        NoiseStr02 = Partlvl * Noise02;
        _Noise01.strength = NoiseStr01;
        _Emission01.rateOverTime = EmRate01;
        _Noise02.strength = NoiseStr01;
        _Emission02.rateOverTime = EmRate02;
        //Debug.Log("WOOOOOOW");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("WOOOOOOW");
            //MaxPart = CurrentPart;
            //CurrentPart = Mathf.RoundToInt(MaxPart);
            //EmRate = CurrentEm;
            //CurrentEm = EmRate;
            //NoiseStr = CurrentNoise;
            //CurrentNoise = NoiseStr;

            _Noise01.strength = NoiseStr01;
            _Emission01.rateOverTime = EmRate01;
            _Noise02.strength = NoiseStr01;
            _Emission02.rateOverTime = EmRate02;
        }

    }
    
}
