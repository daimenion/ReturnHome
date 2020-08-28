using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : AdAndDis
{
    public override void Start()
    {
        myname = "Acid Reflux";
        base.Start();
    }

    public override void DisAdvantageEffect()
    {
        base.DisAdvantageEffect();
        player.DamageAdjust = 0.8f;
    }
}
