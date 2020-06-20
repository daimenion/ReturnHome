using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    ////added to inventory system script
    //Item[] Inventory;
    //int currentItem;
    //void Update()
    //{
    //    if (Inventory[currentItem].aresol)
    //    {
    //        if (Input.GetButton("UseItem"))
    //        {
    //            Inventory[currentItem].UseItem();
    //        }
    //    }
    //    else//Might want some type of cooldown
    //    {
    //        if (Input.GetButtonDown("UseItem"))
    //        {
    //            Inventory[currentItem].UseItem();
    //        }
    //    }
    //}
}

//Begin Items
public abstract class Item : MonoBehaviour
{
    public bool aresol; //Whether this item uses GetButton or GetButtonDown
    public float usesLeft;

    public string myName;
    public string description;
    public string type; //part of the user-facing description
    Interaction interact;
    public bool Equipped;
    public void UseItem()
    {
        OnUse();
        if (usesLeft == 0)
        {
            RemoveItem();
            //Remove item from inventory. In some cases, replace the item with a dead version of itself (Empty Fire Extinguisher can be used as a blunt weapon)
        }
    }
    public virtual void OnUse()
    {
        if (aresol)
        {
            usesLeft -= 1 * Time.deltaTime;
        }
        else if (usesLeft > 0)
        {
            usesLeft -= 1;
        }
    }
    protected void RemoveItem()
    {
        Destroy(this);//May need to update the inventory system 
    }
    protected void interaction() {
        interact = GetComponent<Interaction>();
        if (interact.Interacted) {
            FindObjectOfType<InventorySystem>().AddItem(this);
            this.gameObject.transform.position += new Vector3(100, 500, 300);
            interact.Interacted = false;
        }
    }
    
}
public abstract class Weapon : Item //Weapons: use a collider for weapon range
{
    public float damage;
    protected Collider myRange;
    new void OnUse()
    {
        base.OnUse();
        //Spawn a collider to determine the weapon range
    }

}
//public class Hairspray : Weapon
//{
//    public Hairspray()
//    {
//        aresol = true;
//        usesLeft = 30.0f;
//        myName = "Hairspray";
//        description = "Good Morning Baltimore!";
//        type = "Hair Product";
//        damage = 0.5f;
//    }
//}

//public class Knife : Weapon
//{
//    public Knife()
//    {
//        aresol = false;
//        usesLeft = -1;
//        myName = "Knife";
//        description = "Let me see what you have...";
//        type = "Weapon";
//        damage = 5.0f;
//    }
//}
//public class CafeteriaFood : Item
//{
//    public CafeteriaFood()
//    {
//        aresol = false;
//        usesLeft = 1;
//        myName = "Cafeteria Food";
//        description = "Its probably better than starving... Probably.";
//        type = "Consumable";
//    }
//    new void OnUse()
//    {
//        base.OnUse();
//        GetComponent<PlayerController>().DecreaseHealth(-10f);
//        if (Random.Range(0, 5) == 0)
//        {
//            //gameObject.AddComponent<IllEffect>(); //add the "ill" effect to the player
//        }
//    }

//}

