using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Actor : MonoBehaviour
{
    protected Rigidbody rBody;
    protected Animator anim;
    public GameObject spawnPoint;
    public float speed { set; get; }
    public float health { set; get; }
    public float MaxHealth { set; get; }
    public float AttackDamage { set; get; }

    Vector3 moveDirection;
    public Vector3 LastMoveDirection { set; get; }



    // Start is called before the first frame update
    protected virtual void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        health = MaxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckHealth();

    }

    void CheckHealth() {
        if (health <= 0) {
            Death();
        }
    }

    void UpdateLastMoveDirection() {
        if (moveDirection != Vector3.zero)
        {
            LastMoveDirection = moveDirection;
        }
    }
    public virtual void DecreaseHealth(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, MaxHealth);

        if (amount >= 0) { Debug.Log(name + " took " + amount + " damage."); }
        else { Debug.Log(name + " recovered " + -amount + " health."); }
    }

  

    public virtual void Death() {


    }
}
