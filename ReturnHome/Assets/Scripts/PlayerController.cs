using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Actor
{
    public bool isMoving;
    public float normalSpeed = 5;
    //oxygen
    public float oxygen;
    public float MaxOxygen;
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
    public GameObject ObjectOnHand;
    public GameObject[] statusEffects;
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
        speed = normalSpeed;
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
            AddEffect("Low Oxygen");
        }
        else if (GetComponentInChildren<LowOxygenEffect>())
        {
            GetComponentInChildren<LowOxygenEffect>().EndEffect();
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
    public void DeathAnim()
    {
        anim.Play("Base Layer.playerdeath");
    }
    public void AttackAnim()
    {
        anim.Play("Base Layer.Attack");
    }
    public void AddEffect(string effectName)
    {
        bool effectFound = false;
        
        foreach(GameObject gm in statusEffects)
        {
            if (gm.GetComponent<StatusEffect>().effectName == effectName)
            {
                StatusEffect component = gm.GetComponent<StatusEffect>();
                StatusEffect[] allEffects = GetComponentsInChildren<StatusEffect>();
                bool effectExists = false;
                foreach (StatusEffect se in allEffects)
                {
                    if (se.effectName == component.effectName)
                    {
                        effectExists = true;
                        break;
                    }
                }
                if (!effectExists)
                {
                    GameObject newEffect = Instantiate(gm, transform.position, transform.rotation);
                    newEffect.transform.parent = transform;
                    FindObjectOfType<StatusUI>().AddEffect(newEffect.GetComponent<StatusEffect>());
                }
                effectFound = true;
                break;
            }
        }
        if (!effectFound) print("Effect not found!");
    }
}
