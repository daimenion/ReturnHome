using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameScript : MonoBehaviour
{
    public bool isBroken = true;
    CustomGameManager GameManager;
    void Awake() {
        GameManager = FindObjectOfType<CustomGameManager>();
    }
    protected void failure()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Electrocute(100f);//Temp Value for Mike Test, to kill player
        FindObjectOfType<PlayerController>().Electrocute(10f);

    }
    protected void success()
    {
        isBroken = false;
        //What do we put here?
        GameManager.AdjustShipHealth(GameManager.MaxShipHealth * 0.15f);
    }
}
