using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpacker : AdAndDis
{
    // Start is called before the first frame update
    public override void Start()
    {
        Advantage = true;
        myname = "Backpacker";
        base.Start();

    }
    void Update()
    {
        
    }
    public override void AdvantageEffect()
    {
        base.AdvantageEffect();
        FindObjectOfType<InventorySystem>().Inventory = new Item[6];
        FindObjectOfType<InventorySystem>().extra.SetActive(true);
    }
}
