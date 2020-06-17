using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bee : AI
{
    public enum States
    {
        Idle,
        Wander,
        Attack,
        Dead
    }
    public States CurrentState { set; get; } = States.Wander;
    public GameObject BHParent;
    Vector3 finalPosition;
    public Vector3 RandomPosition;
    public float wanderingRadius;
    public float StoppingDistance;
    // Start is called before the first frame update
    void Start()
    {
        if (BHParent == null)
            BHParent = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void HandleStates()
    {
        if (BHParent.GetComponent<Beehive>().isAttacking())
        {
            CurrentState = States.Attack;
        }
        StartCoroutine(Timer());
        switch (CurrentState)
        {
            case States.Idle:

                break;
            case States.Wander:
                MoveForward();
                break;
            case States.Attack:

                break;
            case States.Dead:

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
        RandomPosition = BHParent.transform.position + UnityEngine.Random.insideUnitSphere * wanderingRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(RandomPosition, out hit, wanderingRadius, 1);
        finalPosition = hit.position;
    }

    public void Attack()
    {
        float dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);
        if(dis <= StoppingDistance)
        {
            agent.isStopped = true;
            //attack
        }
        else
        {
            //chase
        }

    }
}
