using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowOxygenEffect : StatusEffect
{
    public Image VisualEffect;
    int x;
    public LowOxygenEffect() {
        duration = -1;
        effectName = "Low Oxygen";
        effectDescription = "YOU NEED AIR!!!!";
   
    }
    protected override void Update()
    {
        base.Update();
        if (GetComponent<PlayerController>().LowOxygen && x == 0)
        {
            GetComponent<PlayerController>().speed = 5;
            StartCoroutine(FadingEffects());
        }
        else
        {
            //VisualEffect.color = new Color(1, 1, 1, 0.0f);
        }
    }
    IEnumerator FadingEffects() {
        if (x == 0)
        {
            x = 1;
            VisualEffect.color = new Color(1, 1, 1, 0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        VisualEffect.color = new Color(1, 1, 1, 0.0f);
        yield return new WaitForSeconds(0.5f);
        x = 0;

    }

}
