using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMask : Item
{
    // Start is called before the first frame update
    void Update()
    {
        interaction();

    }
    public OxygenMask() {
        aresol = false;
        usesLeft = 20;
        myName = "Oxygen Mask";
        description = "This will give you air";
        type = "Consumable";
    }
    new void OnUse()
    {
        base.OnUse();
        StartCoroutine(Using());
       
    }
    IEnumerator Using() {
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<PlayerController>().oxygen += 3;
        StopCoroutine(Using());
    }
}
