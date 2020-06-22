using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMinigame : Interaction
{
    // Start is called before the first frame update
    public GameObject minigame;
    GameObject myGame;
    override protected void Start()
    {
        base.Start();
        if (minigame == null)
        {
            Destroy(transform.gameObject);
        }
    }
    override protected void myInteraction()
    {
        if (!Interacted) {
        myGame = Instantiate(minigame, transform.parent);
        }
        Interacted = true;
    }
    void Update()
    {
        if (myGame == null)
        {
            Interacted = false;
        }
    }
}
