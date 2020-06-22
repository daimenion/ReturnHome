using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] Items;
    public Item[] Inventory;
    int currentItem;
    public int itemA;
    public int itemB;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        //Items = new List<GameObject>(5);
        //Item = new GameObject[5];
        Inventory = new Item[5];
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        currentItem = FindObjectOfType<InventorySelector>().ItemNumber;
        if (Input.GetButton("UseItem"))
        {
            if (Inventory[currentItem] == null)
            {
                //do nothing
            }
            else if (Inventory[currentItem].aresol)
            {
                Inventory[currentItem].UseItem();
            }
            else//Might want some type of cooldown
            {
                if (Input.GetButtonDown("UseItem"))
                {
                    Inventory[currentItem].UseItem();
                    
                }
            }
        }
        if (Input.GetButton("DropItem")) {
            RemoveItem(currentItem);
        }
        if (Inventory[currentItem] == null) {
            Inventory[currentItem] = null;
        }

    }


    public void AddItem(Item Item) {
        //check if last item of the array is empty
        if (Inventory[Inventory.Length - 1] == null)
        {
            Inventory[Inventory.Length - 1] = Item;
            for (int i = 0; i < Inventory.Length - 1; i++)
            {
                if (Inventory[i] == null)
                {
                    Inventory[i] = Inventory[Inventory.Length - 1];
                    Inventory[Inventory.Length - 1] = null;
                }
            }
        }
        else 
        {
            for (int i = 0; i < Inventory.Length - 1; i++)
            {
                if (Inventory[i] == null)
                {
                    Inventory[i] = Item;
                    //Items[Items.Length - 1] = null;
                }
            }
        }


    }
    public void RemoveItem(int Item) {
        //Inventory[Item]
        DropItem(Item);
        Inventory[Item] = null;
    }

    void DropItem(int Item)
    {
        Inventory[Item].gameObject.transform.position = player.gameObject.transform.position + new Vector3 (Random.Range(-1.5f, 1.5f),0, Random.Range(-1.5f ,1.5f));
    }
    //public void SwitchItems<T>(IList<T> list) {
    //    T Temp = list[itemA];
    //    list[itemA] = list[itemB];
    //    list[itemB] = Temp;
    //}
}
