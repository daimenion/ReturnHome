using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AI
{
    public bool inAir = false;

    public float jumpForce;

    public GameObject ShockGrenade;
    public enum States {
        Idle,
        Move,
        Jump,
        ShockCircle,
        FireBullet,
        RopeAttack
    }

    public States CurrentState { set; get; } = States.Move;
    // Start is called before the first frame update
    void Start()
    {
        speed = 500;
        StartCoroutine(RunAI());
        this.transform.LookAt(playerController.gameObject.transform);
    }
    // Update is called once per frame
    void Update()
    {
        if (rBody.velocity == Vector3.zero) {
            inAir = false;
        }
        CustomGravity();
    }
    void CustomGravity() {

    }
    IEnumerator RunAI(float initialDelay = 2f)
    {
        States previousAIState = CurrentState;

        yield return new WaitForSeconds(initialDelay);

        SetNewAIState(previousAIState);

        HandleStates();
    }
    void SetNewAIState(States previousAIState)
    {
        if (!inAir)
        {
            int number = Random.Range(0, 10);
            if (number >= 9)
                CurrentState = States.Jump;
            float dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);
            if (dis <= 100)
            {
                if (CoolDownStarted == false)
                    CurrentState = States.ShockCircle;
                else
                    CurrentState = States.Move;
            }
            else if (dis > 100 && dis < 300)
            {
                if (CoolDownStarted == false)
                    CurrentState = States.RopeAttack;
                else
                    CurrentState = States.Move;
            }
            else if (dis > 300)
            {
                    CurrentState = States.FireBullet;

            }
            switch (previousAIState)
            {
                case States.FireBullet:
                    CurrentState = States.Move;
                    break;

                case States.ShockCircle:
                    CurrentState = States.Idle;
                    break;

                case States.RopeAttack:
                    CurrentState = States.Move;
                    break;

                case States.Jump:
                    CurrentState = States.Move;
                    break;

                default:
                    break;
            }
        }
        Debug.Log("currentAIState set to: " + CurrentState);
    }
    void HandleStates() {
        StartCoroutine(Timer());
        switch (CurrentState) {
            case States.Idle:
                StartCoroutine(RunAI());
                break;
            case States.Move:
                MoveForward();
                break;
            case States.Jump:
                JumpForward();
                break;
            case States.FireBullet:
                FireBullet();
                break;
            case States.ShockCircle:
                ShockCirlce();
                CoolDownTimer();
                break;
            case States.RopeAttack:
                ropeAttack();
                CoolDownTimer();
                break;
            default:
                break;
        }
    }
    void MoveForward() {
        rBody.velocity = transform.forward * speed * Time.deltaTime;
        spawnPoint.transform.LookAt(playerController.gameObject.transform);
        Instantiate(spawningAttacks,spawnPoint.transform.position, spawnPoint.transform.rotation);
        StartCoroutine(RunAI());
    }
    void JumpForward() {
        if (!inAir)
        {
           //rBody.velocity = new Vector3(transform.forward.x*2, 10, transform.forward.z*2) * jumpForce / 2 * Time.deltaTime;
            rBody.AddForce(new Vector3(transform.forward.x * 2, 10, transform.forward.z * 2) * jumpForce, ForceMode.Force);
            inAir = true;
        }
        StartCoroutine(RunAI());
    }
    void FireBullet() {
        Instantiate(spawningAttacks, spawnPoint.transform.position,spawnPoint.transform.rotation);
        StartCoroutine(RunAI());
    }

    void ShockCirlce() {
        Instantiate(ShockGrenade, spawnPoint.transform.position, spawnPoint.transform.rotation);
        StartCoroutine(RunAI());
    }

    void ropeAttack() {

        StartCoroutine(RunAI());
    }

}
