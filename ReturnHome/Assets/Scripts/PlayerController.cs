using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Actor
{
    public bool isMoving;
    //oxygen
    public float oxygen;
    public bool LowOxygen;
    //Ill
    bool Ill;
    float Illdmg;
    public Slider HPBar;
    public Camera cam;
    public Vector3 CamPos;
    string TypeOfAttack;
    public enum PlayerStates
    {
        Idle,
        Move,
    }
    PlayerStates state;

    // Start is called before the first frame update
    protected override void Awake()
    {
        MaxHealth = 100;
        base.Awake();
    }
    void Start()
    {
        state = PlayerStates.Move;
        speed = 5;
        HPBar.maxValue = MaxHealth;
        HPBar.value = health;
        CamPos = cam.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        HandleStates();

        CheckOxygen();
        HPBar.value = health;
        TypeOfAttack = AttackType;
    }
    void HandleStates()
    {
        switch (state)
        {
            case PlayerStates.Idle:
                break;
            case PlayerStates.Move:
                Move();
                break;
            default:
                break;
        }
    }
    void InputHandle() {

    }

    void Move() {
        anim.SetInteger("PlayerState", 1);
        anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        anim.SetFloat("MoveZ", Input.GetAxis("Vertical"));
        Vector3 moveVector = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.Translate(moveVector);
        isMoving = (moveVector != Vector3.zero);
    }
    //check Oxygen levels and Low Oxygen effects
    void CheckOxygen() {
        if (oxygen <= 0)
        {
            PlayerDecreaseHealth(100, "Oxygen");
            Death();
        }
        else if (oxygen < 40)
        {
            LowOxygen = true;
            GetComponent<LowOxygenEffect>().enabled = true;
        }
        else {
            GetComponent<LowOxygenEffect>().enabled = false;
        }
    }
    void OnTriggerEnter( Collider other) {

        //if (other.CompareTag("EnemyAttacks")) {
        //    StartCoroutine(TakeDamage(0.0f,10.0f));
        //}
        if (other.CompareTag("Room"))
        {

            //if (cam.gameObject.transform.position == other.GetComponentInChildren<Camera>().gameObject.transform.position)
            //{
            //    cam.gameObject.SetActive(false);
            //    cam.GetComponentInChildren<Camera>().enabled = false;
            //}
            cam.gameObject.transform.parent = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("EnemyAttacks"))
        //{
        //    StartCoroutine(TakeDamage(1.0f, 0.2f));
        //}
        if (other.CompareTag("Room"))
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, other.GetComponentInChildren<Camera>().gameObject.transform.position,15*Time.deltaTime);
            if (cam.gameObject.transform.position == other.GetComponentInChildren<Camera>().gameObject.transform.position)
            {
                cam.gameObject.SetActive(false);
                cam.GetComponentInChildren<Camera>().enabled = false;
                other.GetComponentInChildren<Camera>().enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("EnemyAttacks"))
        //{
        //    StopCoroutine("TakeDamage");
        //}
        if (other.CompareTag("Room"))
        {
            cam.gameObject.transform.parent = this.gameObject.transform;
            cam.gameObject.transform.localPosition =  CamPos;
            cam.gameObject.SetActive(true);
            cam.GetComponentInChildren<Camera>().enabled = true;
            other.GetComponentInChildren<Camera>().enabled = false;
        }
    }

    public IEnumerator TakeDamage( float time, float Damage) {
        yield return new WaitForSeconds(time);
        DecreaseHealth(Damage);
        StopCoroutine("TakeDamage");
    }
    public void Electrocute(float Damage)
    {
        StartCoroutine(TakeDamage(0.0f, Damage));
    }
}
