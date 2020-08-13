using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIcons : MonoBehaviour
{
    public int ItemNumber;
    public Image Background;
    InventorySystem inv;
    Sprite defau;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<InventorySystem>();
        defau = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        //OLD======================
        //if (inv.Inventory.Length != 0)
        //{
        //    if (inv.Inventory[ItemNumber] != null)
        //    {
        //        GetComponent<Image>().sprite = inv.Inventory[ItemNumber].GetComponent<SpriteRenderer>().sprite;
        //        GetComponent<Image>().type = Image.Type.Filled;
        //        GetComponent<Image>().fillMethod = Image.FillMethod.Vertical;
        //        GetComponent<Image>().fillAmount = inv.Inventory[ItemNumber].GetComponent<Item>().usesLeft / inv.Inventory[ItemNumber].GetComponent<Item>().MaxUsesLeft;
        //        Background.color = new Color(1,1,1,0.25f);
        //        Background.sprite = inv.Inventory[ItemNumber].GetComponent<SpriteRenderer>().sprite;
        //    }
        //    else
        //    {
        //        GetComponent<Image>().sprite = defau;
        //        Background.sprite = defau;
        //    }
        //}
        //else {
        //    GetComponent<Image>().sprite = defau;
        //    Background.sprite = defau;
        //}

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            ItemNumber--;
            if (ItemNumber < 0)
            {
                ItemNumber = inv.Inventory.Length - 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ItemNumber++;
            if (ItemNumber > inv.Inventory.Length - 1)
            {
                ItemNumber = 0;
            }
        }
        updateIcon();
    }

    void updateIcon() {

        if (inv.Inventory.Length != 0)
        {
            if (inv.Inventory[ItemNumber] != null)
            {
                GetComponent<Image>().sprite = inv.Inventory[ItemNumber].GetComponent<SpriteRenderer>().sprite;
                GetComponent<Image>().type = Image.Type.Filled;
                GetComponent<Image>().fillMethod = Image.FillMethod.Vertical;
                GetComponent<Image>().fillAmount = inv.Inventory[ItemNumber].GetComponent<Item>().usesLeft / inv.Inventory[ItemNumber].GetComponent<Item>().MaxUsesLeft;
                Background.color = new Color(1, 1, 1, 0.25f);
                Background.sprite = inv.Inventory[ItemNumber].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                GetComponent<Image>().sprite = defau;
                Background.sprite = defau;
            }
        }
        else
        {
            GetComponent<Image>().sprite = defau;
            Background.sprite = defau;
        }
    }
}
