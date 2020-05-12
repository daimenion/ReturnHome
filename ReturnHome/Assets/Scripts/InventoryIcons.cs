using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIcons : MonoBehaviour
{
    public int ItemNumber;
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
        if (inv.Items.Length != 0)
        {
            if (inv.Items[ItemNumber] != null)
            {
                GetComponent<Image>().sprite = inv.Items[ItemNumber].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                GetComponent<Image>().sprite = defau;
            }
        }
        else {
            GetComponent<Image>().sprite = defau;
        }
    }
}
