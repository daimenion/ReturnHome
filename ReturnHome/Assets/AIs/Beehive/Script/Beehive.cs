using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Beehive : AI
{
    //public GameObject Viewcircle;
    public enum States
    {
        Idle,
        Wander,
        Attack,
        Dead
    }
    float dis;
    public States CurrentState { set; get; } = States.Wander;

    Vector3 finalPosition;
    public Vector3 RandomPosition;
    public float wanderingRadius;
   // public bool attacking;
    //public GameObject ViewLight;
    public GameObject sprite;
    Quaternion iniRot;
    public int StoppingDistance;
   // bool Chasing;
    private GameObject Player;
    public Vector3 AttackCoords;
    // Start is called before the first frame update
    void Start()
    {
        speed = 250;
        wanderingRadius = 25;
        iniRot = sprite.transform.rotation;
        RandomMovePoint();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HandleStates();
    }

    public virtual void HandleStates()
    {
        if (health < MaxHealth)
        {
            CurrentState = States.Attack;
            StoppingDistance = 3;
        }
        StartCoroutine(Timer());
        switch (CurrentState)
        {
            case States.Idle:
                StartCoroutine(Timer());
                break;
            case States.Wander:
                MoveForward();
                break;
            case States.Attack:
                UpdateAttack();
                break;
            case States.Dead:
                //Honey interaction
                break;
            default:
                break;
        }
    }

    public virtual void MoveForward()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete && (agent.remainingDistance > 0 && agent.remainingDistance < 1))
        {
            RandomMovePoint();
        }
        if (CurrentState != States.Attack)
        {
            agent.SetDestination(new Vector3(finalPosition.x, this.transform.position.y, finalPosition.z));
        }
        //Debug.Log(agent.remainingDistance + this.name);
    }

    public void RandomMovePoint()
    {
        RandomPosition = this.transform.position + UnityEngine.Random.insideUnitSphere * wanderingRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(RandomPosition, out hit, wanderingRadius, 1);
        finalPosition = hit.position;
    }

    public void UpdateAttack()
    {
        if(dis < StoppingDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
        AttackCoords = Player.transform.position;
    }

    public bool isAttacking()
    {
        return CurrentState == States.Attack;
    }
    //spawn bees
}
