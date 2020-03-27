using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Actor
{

    protected PlayerController playerController;
    IEnumerator spriteFlashCoroutine;
    public GameObject spawningAttacks;

    protected bool CoolDownStarted;
    public float cooldown;
    float maxCoolDown;

    protected override void Awake()
    {
        base.Awake();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        maxCoolDown = cooldown;
        CoolDownStarted = false;
    }

    //changes z-rotation to look at player
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
    public void CoolDownTimer()
    {
        CoolDownStarted = true;
    }
    public IEnumerator Timer()
    {
        if (CoolDownStarted)
        {
            yield return new WaitForSeconds(1);
            cooldown--;
        }
        if (cooldown <= 0)
        {
           cooldown = maxCoolDown;
           CoolDownStarted = false;
           StopCoroutine(Timer());
        }
        
    }

}
