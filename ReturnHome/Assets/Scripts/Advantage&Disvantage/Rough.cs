using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rough : AdAndDis
{
    // Start is called before the first frame update
    GeneralGhost[] ghosts;
    public override void Start()
    {
        Advantage = true;
        base.Start();
       
    }
    void Update() {
        AdvantageEffect();
    }
    public override void AdvantageEffect()
    {
        base.AdvantageEffect();
        ghosts = FindObjectsOfType<GeneralGhost>();
        for(int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].DamageAdjust = 1.15f;

        }
    }

    // Update is called once per frame
}
