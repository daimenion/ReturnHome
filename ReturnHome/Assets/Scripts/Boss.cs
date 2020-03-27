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
        float dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);
        switch (previousAIState)
        {
            case States.Idle:
                CurrentState = States.Move;
                break;
            default:
                break;
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

            default:
                break;
        }
    }
    void MoveForward() {
        rBody.velocity = transform.forward * speed * Time.deltaTime;
        StartCoroutine(RunAI());
    }

}
