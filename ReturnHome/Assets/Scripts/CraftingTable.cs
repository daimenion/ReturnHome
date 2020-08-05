using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    Interaction interaction;
    InventorySystem inventory;
    Item[] StoredItems;
    Item Flamethrower;

    private bool bHairspray;
    private bool bLighter;
    private bool bVacuumCleaner;
    private bool bPropane;

    private int[] itemIndex = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<Interaction>();
        inventory = FindObjectOfType<InventorySystem>();

        bHairspray = false;
        bLighter = false;
        bVacuumCleaner = false;
        bPropane = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.Interacted) {
            CheckInventory();
            //option to make flamethrower
            //option to make Molotov Vacuum Cleaner
        }
    }

    void CheckInventory() {
        for (int i = 0; i < inventory.Inventory.Length - 1; i++) {
            if (inventory.Inventory[i].myName == "HairSpray")
            {
                bHairspray = true;
                itemIndex[0] = i;
            }
            
            if(inventory.Inventory[i].myName == "Lighter")
            {
                bLighter = true;
                itemIndex[1] = i;
            }
        }

        for (int i = 0; i < inventory.Inventory.Length - 1; i++)
        {
            if (inventory.Inventory[i].myName == "Vacuum Cleaner")
            {
                bVacuumCleaner = true;
                itemIndex[2] = i;
            }

            if (inventory.Inventory[i].myName == "Propane Pack")
            {
                bPropane = true;
                itemIndex[3] = i;
            }
        }
    }

    void MakeFlamethrower()
    {
        if (bHairspray && bLighter)
        {
            inventory.RemoveItem(itemIndex[0]);
            inventory.RemoveItem(itemIndex[1]);
            inventory.AddItem(Flamethrower);
        }
    }

    void MakeMolotovVacuum()
    {
        if (bVacuumCleaner && bPropane)
        {
            inventory.RemoveItem(itemIndex[2]);
            inventory.RemoveItem(itemIndex[3]);
            //inventory.AddItem(Flamethrower); Add Molotov Vacuum Cleaner
        }
    }
}
