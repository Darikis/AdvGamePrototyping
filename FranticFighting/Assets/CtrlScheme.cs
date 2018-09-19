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
    public bool Player1;
    public bool Player2;
    public bool Player3;
    public bool Player4;
    public bool Player5;
    public bool Green;
    public bool Yellow;
    public bool Grey = true;
    public Image imgB1;
    public Image imgB2;
    public Image imgB3;
    public Image imgB4;
    public string ButtonSuffix;


}