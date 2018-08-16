using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ControlSchem")]

public class CtrlScheme : ScriptableObject
{

    public KeyCode B1;
    public KeyCode B2;
    public KeyCode B3;
    public KeyCode B4;
    public bool ReadyToAct = true;
    public Image img;
}