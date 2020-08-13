using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    Interaction interaction;
    InventorySystem inventory;
    Item[] StoredItems;
    public Item Flamethrower;
    public Item ModVaccumCleaner;
    public GameObject Canvas;

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
            OpenTable();
        }
    }
    void OpenTable() {
        Canvas.SetActive(true);
        Canvas.GetComponent<Canvas>().worldCamera = Camera.allCameras[0];
      
    }

    void CheckInventory() {
        for (int i = 0; i < inventory.Inventory.Length - 1; i++) {
            if (inventory.Inventory[i].myName == "Hairspray")
            {
                bHairspray = true;
                itemIndex[0] = i;
            }
            
            if(inventory.Inventory[i].myName == "Lighter")
            {
                bLighter = true;
                itemIndex[1] = i;
            }
            if (bLighter && bHairspray) {
                return;
            }
        }
    }
    void CheckVaccum() {
        for (int i = 0; i < inventory.Inventory.Length - 1; i++)
        {
            if (inventory.Inventory[i].myName == "Vaccum Cleaner")
            {
                bVacuumCleaner = true;
                itemIndex[2] = i;
            }

            if (inventory.Inventory[i].myName == "Toy")
            {
                bPropane = true;
                itemIndex[3] = i;
            }
            if (bPropane && bVacuumCleaner)
            {
                return;
            }
        }
    }

    public void MakeFlamethrower()
    {
        CheckInventory();
        if (bHairspray && bLighter)
        {
            //inventory.RemoveItem(itemIndex[0]);
            Destroy(inventory.Inventory[itemIndex[0]].gameObject);
            Destroy(inventory.Inventory[itemIndex[1]].gameObject);
            GameObject item = Instantiate(Flamethrower.gameObject,
                        transform.position, new Quaternion(0, 45, 0, 1)) as GameObject;
            item.GetComponent<BoxCollider>().enabled = false;
            item.GetComponent<Interaction>().Interacted = true;
            //Exit();
        }
    }

    public void MakeMolotovVacuum()
    {
        CheckVaccum();
        if (bVacuumCleaner && bPropane)
        {
            Destroy(inventory.Inventory[itemIndex[2]].gameObject);
            Destroy(inventory.Inventory[itemIndex[3]].gameObject);
            GameObject item = Instantiate(ModVaccumCleaner.gameObject,
                       transform.position, new Quaternion(0, 45, 0, 1)) as GameObject;
            item.GetComponent<BoxCollider>().enabled = false;
            item.GetComponent<Interaction>().Interacted = true;
            //inventory.AddItem(Flamethrower); Add Molotov Vacuum Cleaner

            //Exit();
        }
    }

    void Exit() {
        Canvas.SetActive(false) ;
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Exit();
            interaction.Interacted = false;
        }
    }
}
