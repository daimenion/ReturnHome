using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    //public string[] name;
    //[TextArea(3, 10)]
    //public string[] sentences;
    public int id;
    //public string name;
    [TextArea(3, 10)]
    public string sentences;
    public string[] choices;
    public int[] choiceid;
    public bool End;
    public bool Delay;
    public float DelayTime;
    public bool NoSkip;
}
