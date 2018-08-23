using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Display.displays.Length > 1)
        {
            //display 0 is set by default
            Display.displays[1].Activate();
            Display.displays[1].SetParams(Mathf.RoundToInt(0.5f), 1, 0, 0);
        }
        if (Display.displays.Length > 2)
        {
            Display.displays[2].Activate();
            Display.displays[2].SetParams(Mathf.RoundToInt(0.5f), 1, 0, 0);
        }
    }
}
