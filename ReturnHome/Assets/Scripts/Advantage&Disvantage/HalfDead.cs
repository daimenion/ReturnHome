using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDead : AdAndDis
{
    // Start is called before the first frame update
    public override void Start()
    {
        myname = "HalfDead";
        base.Start();
    }

    public override void DisAdvantageEffect()
    {
        base.DisAdvantageEffect();
        player.DamageAdjust = 1.15f;
    }
}
