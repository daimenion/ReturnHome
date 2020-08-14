using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.U2D.IK;

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
    public Collider WeaponHitBox;
    Vector3 OriRot;
    public virtual void Start() { 
        if (WeaponHitBox != null)
        OriRot = WeaponHitBox.gameObject.transform.localEulerAngles; 
    
    }
    public void UseItem()
    {
        if (FindObjectOfType<MinigameScript>() == null)
        {
            OnUse();
            if (usesLeft <= 0 && gone)
            {
                StartCoroutine(RemoveItem());

            }
        }
    }
    public virtual void Update()
    {
        if (Equipped)
        {
            //this.gameObject.GetComponent<Interaction>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            if (Input.GetButtonDown("UseItem"))
            {
                this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            }
            if (Input.GetButtonUp("UseItem")) {
                StartCoroutine(wait());
            }
        }
        else if (transform.parent != null && !Equipped)
        {
            this.gameObject.transform.localPosition += new Vector3(100, 500, 300);
        }
        if (transform.parent == null) {
            if(WeaponHitBox != null) 
            WeaponHitBox.gameObject.transform.localEulerAngles = OriRot;
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
    protected IEnumerator RemoveItem()
    {
        yield return new WaitForSeconds(1);
        transform.parent = null;
        FindObjectOfType<InventorySystem>().ItemAmount--;

        Destroy(this.gameObject);//May need to update the inventory system 
    }
    protected void interaction() {
        interact = GetComponent<Interaction>();
        if (interact.Interacted && FindObjectOfType<InventorySystem>().ItemAmount < FindObjectOfType<InventorySystem>().Inventory.Length)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<InventorySystem>().AddItem(this);
            this.gameObject.transform.localPosition += new Vector3(100, 500, 300);
            //this.gameObject.transform.parent = FindObjectOfType<PlayerController>().gameObject.transform;
            //this.gameObject.transform.position += new Vector3(100, 500, 300);
            transform.Find("Canvas").gameObject.SetActive(false);
            if (interact.Interacted) { FindScale();}
            interact.Interacted = false;
            interact.enabled = false;
            FindObjectOfType<PlayerController>().GetComponentInChildren<Animator>().Play("Base Layer.PickUp");
        }
    }
    //fix weapon flip with player
    public Vector3 meleeRot;
    GameObject parents;
    void FindScale()
    {
        parents = FindObjectOfType<PlayerController>().gameObject.GetComponentInChildren<IKManager2D>().gameObject;
        if (parents.transform.localScale.x == 0.1f)
        {
            if (WeaponHitBox != null)

                WeaponHitBox.gameObject.transform.localEulerAngles = meleeRot;
        }
        if (parents.transform.localScale.x == -0.1f)
        {
            if (WeaponHitBox != null)

                WeaponHitBox.gameObject.transform.localEulerAngles = OriRot;
        }
    }
    public IEnumerator wait() {
        yield return new WaitForSeconds(1f);
        this.gameObject.transform.localPosition += new Vector3(100, 500, 300);
    }
}
public abstract class Weapon : Item //Weapons: use a collider for weapon range
{
    public float damage;
    protected Collider myRange;
    Camera[] cameras;

    public bool Melee;
    public override void OnUse()
    {
        base.OnUse();
        if (WeaponHitBox != null)
            WeaponHitBox.enabled = true;
        if (Melee)
        {
            FindObjectOfType<PlayerController>().AttackAnim();

        }

        //Spawn a collider to determine the weapon range
    }
    public override void Start() {
        base.Start();
        cameras = FindObjectsOfType<Camera>();
       
    }
    public override void Update() {
        base.Update();
        if (Equipped)
        {

            if (FindObjectOfType<PlayerController>().rig.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                if (WeaponHitBox != null)
                {
                    WeaponHitBox.enabled = false;
                }
            }

            FindObjectOfType<PlayerController>().AttackDamage = damage;
            //this.gameObject.GetComponent<Interaction>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            //this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            if (!Melee)
            {
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

