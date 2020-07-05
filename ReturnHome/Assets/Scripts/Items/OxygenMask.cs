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
        aresol = true;
        usesLeft = 20;
        myName = "Oxygen Mask";
        description = "This will give you air";
        type = "Consumable";
    }
    public override void OnUse()
    {
        base.OnUse();
        StartCoroutine(Using());
       
    }
    IEnumerator Using() {
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<PlayerController>().oxygen = Mathf.Clamp(FindObjectOfType<PlayerController>().oxygen + 0.5f, 0, 100); ;
        StopCoroutine(Using());
    }
}
