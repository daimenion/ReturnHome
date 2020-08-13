using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class InventorySelector : MonoBehaviour
{
    public int ItemNumber;
    InventorySystem inv;
    PlayerController player;
    int PerviousNumber;
    Text name;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<InventorySystem>();
        player = FindObjectOfType<PlayerController>();
        name = transform.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            PerviousNumber = ItemNumber;
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[ItemNumber].Equipped = false;
            }
            if (ItemNumber >= inv.Inventory.Length - 1)
            {
                //transform.localPosition = new Vector3(-200, transform.localPosition.y);
                ItemNumber = 0;
            }
            else {
                ItemNumber++;
                //UpdateSelected(100);
            }



        }
       else if (Input.GetAxis("Mouse ScrollWheel") > 0)
       {
            PerviousNumber = ItemNumber;
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[PerviousNumber].Equipped = false;
            }
            if (ItemNumber <= 0)
            {
                //transform.localPosition = new Vector3(200, transform.localPosition.y);
                ItemNumber = inv.Inventory.Length-1;

            }
            else {
                ItemNumber--;
                //UpdateSelected(-100);
            }

       }
        if (inv.Inventory[ItemNumber] != null)
        {
            inv.Inventory[ItemNumber].Equipped = true;
            name.text = inv.Inventory[ItemNumber].myName;

        }
        else {
            name.text ="";
        }
    }

    public void UpdateSelected(float x) {
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, 0);

    }
}
