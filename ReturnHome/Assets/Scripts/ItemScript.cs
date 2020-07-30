using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    public float MaxUsesLeft;

    public string myName;
    public string description;
    public string type; //part of the user-facing description
    protected Interaction interact;
    public bool Equipped;
    public bool gone;

    public void UseItem()
    {
        OnUse();
        if (usesLeft <= 0&& gone)
        {
            RemoveItem();
            //Remove item from inventory. In some cases, replace the item with a dead version of itself (Empty Fire Extinguisher can be used as a blunt weapon)
        }
    }
    public virtual void Update()
    {
        if (Equipped)
        {
            //this.gameObject.GetComponent<Interaction>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0);

        }
        else if (transform.parent != null && !Equipped)
        {
            this.gameObject.transform.localPosition += new Vector3(100, 500, 300);
        }
    }
    public virtual void OnUse()
    {
        if (FindObjectOfType<MinigameScript>() == null)
        {
            if (aresol)
            {
                usesLeft -= 1 * Time.deltaTime;
            }
            else if (usesLeft > 0)
            {
                usesLeft -= 1;
                FindObjectOfType<PlayerController>().AttackAnim();
            }
        }
    }
    protected void RemoveItem()
    {
        transform.parent = null;
        Destroy(this.gameObject);//May need to update the inventory system 
    }
    protected void interaction() {
        interact = GetComponent<Interaction>();
        if (interact.Interacted)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<InventorySystem>().AddItem(this);
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            //this.gameObject.transform.parent = FindObjectOfType<PlayerController>().gameObject.transform;
            //this.gameObject.transform.position += new Vector3(100, 500, 300);
            transform.Find("Canvas").gameObject.SetActive(false);
            interact.Interacted = false;

        }
    }
    
}
public abstract class Weapon : Item //Weapons: use a collider for weapon range
{
    public float damage;
    protected Collider myRange;
    Camera[] cameras;
    public Collider WeaponHitBox;
    new void OnUse()
    {
        base.OnUse();
        WeaponHitBox.enabled = true;
        //Spawn a collider to determine the weapon range
    }
    void Start() {
        cameras = FindObjectsOfType<Camera>();
       
    }
    public override void Update() {
        if (Equipped)
        {
            FindObjectOfType<PlayerController>().AttackDamage = damage;
            //this.gameObject.GetComponent<Interaction>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0);

            for (int i = 0; i < cameras.Length; i++)
            {
                if (Camera.allCameras[0].isActiveAndEnabled)
                {
                    Vector2 PositionOnScreen = Camera.allCameras[0].WorldToViewportPoint(transform.position);

                    Vector2 MouseOnScreen = (Vector2)Camera.allCameras[0].ScreenToViewportPoint(Input.mousePosition);
                    float angle = AngleBetweenTwoPoints(PositionOnScreen, MouseOnScreen);
                    this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 45, 0f));
                }
            }
        }
        else if (transform.parent != null && !Equipped) {
            this.gameObject.transform.localPosition += new Vector3(100, 500, 300);
        }

       
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
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

