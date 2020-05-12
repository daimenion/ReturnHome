using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        //Items = new List<GameObject>(5);
        Items = new GameObject[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {

            AddItem(FindObjectOfType<PickUpAbleObjects>().gameObject);
        }
        if (Input.GetKeyUp(KeyCode.O))
        {

            RemoveItem(0);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {

            SwitchItems(Items, 1,3);
        }
    }

    public void AddItem(GameObject Item) {
        //check if last item of the array is empty
        if (Items[Items.Length - 1] == null)
        {
            Items[Items.Length - 1] = Item;
            for (int i = 0; i < Items.Length - 1; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = Items[Items.Length - 1];
                    Items[Items.Length - 1] = null;
                }
            }
        }
        else 
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = Item;
                    //Items[Items.Length - 1] = null;
                }
            }
        }


    }
    public void RemoveItem(int Item) {
        Items[Item] = null;
    }
    public void SwitchItems<T>(IList<T> list,int A, int B) {
        T Temp = list[A];
        list[A] = list[B];
        list[B] = Temp;
    }
}
