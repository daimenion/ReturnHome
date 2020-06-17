using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : Item
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public Honey()
    {
        aresol = false;
        usesLeft = 1;
        myName = "Honey";
        description = "It tastes sweet.";
        type = "Consumable";
    }
}
