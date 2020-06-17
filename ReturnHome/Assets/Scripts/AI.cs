using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : Actor
{

    protected PlayerController playerController;
    IEnumerator spriteFlashCoroutine;
    public GameObject spawningAttacks;
    public NavMeshAgent agent;
    public bool SeemPlayer;
    //skill cooldown
    protected bool CoolDownStarted;
    int CoolDownOnce;
    public float cooldown;
    float maxCoolDown;
    protected override void Awake()
    {
        base.Awake();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        maxCoolDown = cooldown;
        CoolDownStarted = false;
        agent = GetComponent<NavMeshAgent>();
    }
    // look at player
    protected virtual void FacePlayer()
    {
        Vector3 distanceToPlayer = playerController.transform.position - transform.position;

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = Mathf.Rad2Deg * Mathf.Atan2(distanceToPlayer.x, distanceToPlayer.y);
        transform.eulerAngles = -currentRotation;
    }
    //handle taking damage from player attacks
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitBox"))
        {
            //DecreaseHealth(playerController.attack);

            if (spriteFlashCoroutine != null)
            {
                StopCoroutine(spriteFlashCoroutine);
            }
            StartCoroutine(spriteFlashCoroutine);
        }
    }
    //set seem player
    void SetSeemplayer(bool x)
    {
        SeemPlayer = x;
    }

    //Set cool down timer
    public void CoolDownTimer()
    {
        CoolDownStarted = true;
        CoolDownOnce++;
    }

    //timer starts and resets
    public IEnumerator Timer()
    {
        if (CoolDownOnce == 1)
        {
            if (CoolDownStarted)
            {
                yield return new WaitForSeconds(1);
                cooldown--;
                CoolDownOnce = 0;
            }
        }
        if (cooldown <= 0)
        {
            cooldown = maxCoolDown;
  
            CoolDownStarted = false;
            StopCoroutine(Timer());
            CoolDownOnce = 0;
        }
        StopCoroutine(Timer());
    }

}
