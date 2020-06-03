using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class InventorySelector : MonoBehaviour
{
    public int ItemNumber;
    InventorySystem inv;
    PlayerController player;
    int PerviousNumber;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<InventorySystem>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            PerviousNumber = ItemNumber;
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[PerviousNumber].Equipped = false;
            }
            ItemNumber++;
            UpdateSelected(100);
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[ItemNumber].Equipped = true;
            }
            if (ItemNumber > inv.Inventory.Length-1)
            {
                transform.localPosition = new Vector3(-200, transform.localPosition.y);
                ItemNumber = 0;

            }

        }
       else if (Input.GetAxis("Mouse ScrollWheel") < 0)
       {
            PerviousNumber = ItemNumber;
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[PerviousNumber].Equipped = false;
            }
            ItemNumber--;
            UpdateSelected(-100);
            if (inv.Inventory[PerviousNumber] != null)
            {
                inv.Inventory[ItemNumber].Equipped = true;
            }
            if (ItemNumber < 0)
            {
                transform.localPosition = new Vector3(200, transform.localPosition.y);
                ItemNumber = inv.Inventory.Length-1;

            }
       }
    }

    public void UpdateSelected(float x) {
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, 0);

    }
}
