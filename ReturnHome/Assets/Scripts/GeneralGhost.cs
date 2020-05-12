using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralGhost : AI
{

    public GameObject Viewcircle;
    public enum States
    {
        Idle,
        Wander,
        SeemPlayer,
        Attack,
    }
    float dis;
    public States CurrentState { set; get; } = States.Wander;

    Vector3 finalPosition;
    public Vector3 RandomPosition;
    public float wanderingRadius;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        speed = 500;
        wanderingRadius = 25;
        agent.updateRotation = false;
        StartCoroutine(Rotate());
    }
    public virtual void HandleStates()
    {
        CheckFirst();
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
            case States.SeemPlayer:
                ChasePlayer();
                CoolDownTimer();
                break;
            case States.Attack:
                CoolDownTimer();
                Attack();
                break;
            default:
                break;
        }
        //StopCoroutine(RunAI());
    }
    // check to switch states
    void CheckFirst()
    {
        if (SeemPlayer)
        {
            CurrentState = States.SeemPlayer;
            if (dis < 5)
            {
                CurrentState = States.Attack;
            }

        }
        else
        {
            CurrentState = States.Wander;
            agent.stoppingDistance = 0;
        }


    }
    // Update is called once per frame
    void Update()
    {
            HandleStates();
    }
    public virtual void MoveForward()
    {
        agent.SetDestination(new Vector3(finalPosition.x, this.transform.position.y , finalPosition.z));
        Debug.Log(agent.remainingDistance + this.name);
        if (agent.pathStatus == NavMeshPathStatus.PathComplete&&(agent.remainingDistance > 0 && agent.remainingDistance < 1))
        {
            StartCoroutine(Rotate());
        }

    }
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.0f);
        RandomPosition = this.transform.position + UnityEngine.Random.insideUnitSphere * wanderingRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(RandomPosition, out hit, wanderingRadius, 1);
        finalPosition = hit.position;

        StopCoroutine(Rotate());
    }
    public virtual void Attack() {
        //something
        
    }
    public virtual void ChasePlayer() {
        agent.SetDestination(playerController.transform.position);
        agent.stoppingDistance = 5;
    }
}
