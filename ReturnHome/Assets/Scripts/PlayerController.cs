using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Actor
{
    public bool isMoving;
    //oxygen
    public float oxygen;
    public float MaxOxygen;
    public bool LowOxygen;
    //Ill
    bool Ill;
    float Illdmg;
    //public Slider HPBar;
    public bool bCoffee;
    public Camera cam;
    public Vector3 CamPos;
    string TypeOfAttack;
    public Transform rig;
    Image healthbar;
    Image oxy;
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
        oxygen = MaxOxygen;
        state = PlayerStates.Move;
        speed = 5;
        //HPBar.maxValue = MaxHealth;
        //HPBar.value = health;
        CamPos = cam.gameObject.transform.localPosition;
        healthbar = GameObject.Find("PlayerHealthBar").GetComponent<Image>();
        oxy = GameObject.Find("OxygenBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / MaxHealth;
        oxy.fillAmount = oxygen / MaxOxygen;
        //Move();
        HandleStates();

        CheckOxygen();
        //HPBar.value = health;
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
        anim.SetBool("isMoving", isMoving);
        if (Input.GetAxis("Horizontal") > 0)
        {
            rig.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rig.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
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
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided");
        if (other.tag == "EnemyAttacks")
        {
            PlayerDecreaseHealth(1.0f, "Ghost");

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
            //make objects visible 
            other.transform.Find("fog").gameObject.SetActive(false);
            //move camera
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
            other.transform.Find("fog").gameObject.SetActive(true);
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
        //StartCoroutine(TakeDamage(0.0f, Damage)); Change damage to new damage type when it's available
        PlayerDecreaseHealth(10, "Electricity");
        anim.Play("Base Layer.electrocution", 0, .25f);
    }

    public IEnumerator Coffee(float time, int newSpeed)
    {
        speed = newSpeed;
        yield return new WaitForSeconds(time);
        bCoffee = false;
        speed = 5;
        StopCoroutine("Coffee");
    }
}
