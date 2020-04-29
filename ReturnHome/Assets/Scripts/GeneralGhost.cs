using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGhost : AI
{
    public enum States
    {
        Idle,
        Wander,
    }
    float dis;
    public States CurrentState { set; get; } = States.Wander;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        StartCoroutine(RunAI());
    }
    void HandleStates()
    {
        StartCoroutine(Timer());
        dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);
        switch (CurrentState)
        {
            case States.Idle:
                CoolDownTimer();
                break;
            case States.Wander:
                MoveForward();
                CoolDownTimer();
                break;
            default:
                break;
        }


    }
    // Update is called once per frame
    void Update()
    {
        //MoveForward();
        if (dis < 1)
        {
            CurrentState = States.Idle;
        }
        else
            CurrentState = States.Wander;
    }
    void MoveForward()
    {
        rBody.velocity = transform.forward * speed * Time.deltaTime;
        if (CoolDownStarted == false)
        {
            StartCoroutine(Rotate());
        }
    }

    IEnumerator RunAI()
    {

        yield return new WaitForSeconds(1f);
        HandleStates();

    }

    IEnumerator Rotate()
    {
        switch (Random.Range(1, 4)) {
            case 1 :
                LastMoveDirection = Vector3.up;
                break;

            case 2:
                LastMoveDirection = Vector3.down;
                break;

            case 3:
                LastMoveDirection = Vector3.left;
                break;

            case 4:
                LastMoveDirection = Vector3.right;
                break;

            default:

                break;

        }
        yield return new WaitForSeconds(0.5f);
        transform.Rotate(LastMoveDirection, Space.World);
        StopCoroutine(Rotate());
    }
}
