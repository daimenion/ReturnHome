using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameScript : MonoBehaviour
{
    public AudioClip openClip;
    public AudioClip failureClip;
    public AudioClip winClip;
    public AudioSource audioPlayer;
    public bool isBroken = true;
    CustomGameManager GameManager;
    void Awake() {
        GameManager = FindObjectOfType<CustomGameManager>();
        audioPlayer = GetComponent<AudioSource>();
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
        GameManager.AdjustShipHealth((GameManager.MaxShipHealth * 0.20f)/ GameManager.MaxShipHealth);
    }
}
