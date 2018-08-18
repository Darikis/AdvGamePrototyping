using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterParticleCtrl : MonoBehaviour {


    public ParticleSystem Part01;
    public ParticleSystem Part02;
    public ParticleSystem.EmissionModule Emission;
    public ParticleSystem.NoiseModule Noise;
    public float Partlvl;
    public float MaxPart;
    public int CurrentMax;
    public float EmRate;
    public float CurrentEm;
    public float NoiseStr;
    public float CurrentNoise;

    // Use this for initialization
    void Start () {

        //Part01.emissionRate = PartMax;
        
        Emission = Part01.emission;
        Noise = Part01.noise;
        CurrentMax = Part01.maxParticles;
        CurrentEm = Part01.emissionRate;
        CurrentNoise = Noise.strength.constant;

	}
	
	// Update is called once per frame
	void Update () {
        MaxPart = Partlvl * CurrentMax;
        EmRate = Partlvl * CurrentEm;
        NoiseStr = Partlvl * CurrentNoise * 2;
        if (Input.GetKey("b"))
        {

            Part01.maxParticles = Mathf.RoundToInt(MaxPart);
            Noise.strength = NoiseStr;
            Emission.rate = EmRate;
        }
		
	}
}
