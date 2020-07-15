using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameScript : MonoBehaviour
{
    public bool isBroken = true;

    protected void failure()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Electrocute(100f);//Temp Value for Mike Test, to kill player
        //PlayerDecreaseHealth(10, "Electricity");

    }
    protected void success()
    {
        isBroken = false;
        //What do we put here?
        //Script to raise total repair on the whole ship.
    }
}
