using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class InteractMinigame : Interaction
{
    // Start is called before the first frame update
    public GameObject minigame;
    GameObject myGame;
    ParticleSystem particle;
    MinigameScript MinigameScript;
    bool isBroken = true;
    override protected void Start()
    {
        base.Start();
        particle= GetComponent<ParticleSystem>();
        if (minigame == null)
        {
            Destroy(transform.gameObject);
        }
    }
    override protected void myInteraction()
    {
        if (!Interacted && isBroken) {
            myGame = Instantiate(minigame, transform.parent);
            minigame.transform.localPosition = new Vector3(1.5f, 0, 1.5f);
            MinigameScript = myGame.GetComponentInChildren<MinigameScript>();
        }
        Interacted = true;
    }
    void Update()
    {
        if (myGame == null && isBroken)
        {
            Interacted = false;
        }
        else if (isBroken && !MinigameScript.isBroken)
        {
            print("Match");
            particle.Stop();
            isBroken = false;
        }
    }
}
