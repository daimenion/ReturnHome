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
    public int ItemAmount;
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
        if (Input.GetButton("UseItem") && !FindObjectOfType<Pause>().isPaused)
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
        if (Input.GetButtonUp("DropItem")) {
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
            Item.transform.parent = FindObjectOfType<PlayerController>().ObjectOnHand.transform;
            Item.transform.position += new Vector3(100, 500, 300);
            Inventory[Inventory.Length - 1] = Item;
            ItemAmount++;
            for (int i = 0; i < Inventory.Length - 1; i++)
            {
                if (Inventory[i] == null)
                {
                    Inventory[i] = Inventory[Inventory.Length - 1];
                    Inventory[Inventory.Length - 1] = null;
                    //ItemAmount++;

                    return;
                }
            }
        }
        else 
        {
            for (int i = 0; i < Inventory.Length - 1; i++)
            {
                if (Inventory[i] == null)
                {
                    Item.transform.parent = FindObjectOfType<PlayerController>().gameObject.transform;
                    Item.transform.position += new Vector3(100, 500, 300);
                    Inventory[i] = Item;
                    ItemAmount++;

                    return;
                    //Items[Items.Length - 1] = null;
                }
            }
        }



    }
    public void RemoveItem(int Item) {
        //Inventory[Item]
        DropItem(Item);
        Inventory[Item] = null;
        ItemAmount--;
    }

    void DropItem(int Item)
    {
        Inventory[Item].gameObject.transform.parent = null;
        Inventory[Item].GetComponent<Interaction>().enabled = true;
        Inventory[Item].Equipped = false;
        Inventory[Item].GetComponent<BoxCollider>().enabled = true;
        Inventory[Item].gameObject.transform.position = player.gameObject.transform.position;
        Inventory[Item].gameObject.transform.rotation = new Quaternion(0, 0, 0,0);
        Inventory[Item].gameObject.transform.localScale = new Vector3(1, 1, 1);


    }
    //public void SwitchItems<T>(IList<T> list) {
    //    T Temp = list[itemA];
    //    list[itemA] = list[itemB];
    //    list[itemB] = Temp;
    //}
}
