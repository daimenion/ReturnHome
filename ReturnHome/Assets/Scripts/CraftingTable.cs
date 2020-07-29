using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    Interaction interaction;
    InventorySystem inventory;
    Item[] StoredItems;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<Interaction>();
        inventory = FindObjectOfType<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.Interacted) { 
            
        }
    }

    void CheckInventory() {
        for (int i = 0; i < inventory.Inventory.Length - 1; i++) {
            if (inventory.Inventory[i].myName == "HairSpray" || inventory.Inventory[i].myName == "Lighter") { 
                
            }
        }
    }
}
