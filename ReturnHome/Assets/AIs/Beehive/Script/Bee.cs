using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Bee : AI
{
    public enum States
    {
        Idle,
        Wander,
        Attack,
        Dead,
        Return
    }
    public States CurrentState { set; get; } = States.Wander;
    public GameObject BHParent;
    Vector3 finalPosition;
    public Vector3 RandomPosition;
    public float wanderingRadius;
    public float StoppingDistance;
    public GameObject sprite;
    Quaternion iniRot;
    int attacking;
    // Start is called before the first frame update
    void Start()
    {
        iniRot = sprite.transform.rotation;
        if (BHParent == null)
        {
            BHParent = this.transform.parent.gameObject;
            this.transform.parent = null;
        }
        RandomMovePoint();
        AttackDamage = 5;
    }

    // Update is called once per frame
    protected override void Update()
    {
        HandleStates();
        //sprite.transform.position = new Vector3(transform.position.x, -0.1f, transform.position.z);
        sprite.transform.rotation = iniRot;
        base.Update();

    }

    public virtual void HandleStates()
    {
        float dist = Vector3.Distance(playerController.transform.position, BHParent.gameObject.transform.position);
        if (BHParent.GetComponent<Beehive>() != null)
        {
           
            if (BHParent.GetComponent<Beehive>().isAttacking() && dist < 10)
                CurrentState = States.Attack;
        }
        else if (BHParent.GetComponent<BeehiveGhost>() != null)
        {
            if (BHParent.GetComponent<BeehiveGhost>().attacking)
                CurrentState = States.Attack;
        }
        if (health < MaxHealth && dist < 10) {
            CurrentState = States.Attack;
        }
        float dis = Vector3.Distance(this.transform.position, BHParent.gameObject.transform.position);
        if (dis > 5)
        {
            CurrentState = States.Return;
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
                Attack();
                break;
            case States.Dead:

                break;
            case States.Return:
                ReturnToBH();
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
        float dis = Vector3.Distance(this.transform.position, BHParent.gameObject.transform.position);
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
        //float dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);

        //if (dis <= StoppingDistance)
        //{
        //    agent.isStopped = true;
        //}
        //else
        //{

        //}
        agent.SetDestination(playerController.transform.position);
        HitBox.enabled = true;
    }
    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {
            playerController.PlayerDecreaseHealth(AttackDamage, "Bee");
            attacking = 1;
        }
    
    }
    void ReturnToBH() {
        agent.SetDestination(BHParent.transform.position);
        if (agent.pathStatus == NavMeshPathStatus.PathComplete && (agent.remainingDistance > 0 && agent.remainingDistance < 1))
        {
            CurrentState = States.Wander;
        }
    }
    public override void Death()
    {
        base.Death();
        Destroy(this.gameObject);
        return;

    }
}
