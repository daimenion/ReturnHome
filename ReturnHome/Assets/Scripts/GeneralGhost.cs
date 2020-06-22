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
    public GameObject ViewLight;
    public GameObject sprite;
    Quaternion iniRot;
    public int StoppingDistance;
    bool Chasing;
    // Start is called before the first frame update
    void Start()
    {
        speed = 250;
        wanderingRadius = 25;
        iniRot = sprite.transform.rotation;
        //agent.updateRotation = false;
        RandomMovePoint();
        ViewLight.GetComponent<Light>().range = Viewcircle.gameObject.GetComponent<ViewCircle>().viewRadius;
        ViewLight.GetComponent<Light>().spotAngle = Viewcircle.gameObject.GetComponent<ViewCircle>().viewAngle;
    }
    public virtual void HandleStates()
    {
        CheckFirst();
        StartCoroutine(Timer());
        dis = Vector3.Distance(this.transform.position, playerController.gameObject.transform.position);
        switch (CurrentState)
        {
            case States.Idle:
                //CoolDownTimer();
                break;
            case States.Wander:
                MoveForward();
                if (CoolDownStarted)
                {
                    CoolDownTimer();
                }
                //CoolDownTimer();
                break;
            case States.SeemPlayer:
                ChasePlayer();
                //CoolDownTimer();
                if (CoolDownStarted)
                {
                    CoolDownTimer();
                }
                break;
            case States.Attack:
                BasicAttack();

                if (!CoolDownStarted)
                {
                    Attack();
                }
                CoolDownTimer();
                break;
            default:
                break;
        }
        //StopCoroutine(RunAI());
    }
    // check to switch states
    void CheckFirst()
    {        //if player is in the view circle 
        if (Viewcircle.GetComponent<ViewCircle>().visibleTargets.Contains(Viewcircle.GetComponent<ViewCircle>().Player))
        {
            SeemPlayer = true;
            Chasing = true;
        }
        else
        {
            SeemPlayer = false;
        }
        if (SeemPlayer)
        {
            CurrentState = States.SeemPlayer;
            ViewLight.GetComponent<Light>().color = Color.red;
            agent.isStopped = true;
            //agent.updateRotation = false;
            if (dis < StoppingDistance)
            {
                //agent.updateRotation = false;
                agent.isStopped = true;
                CurrentState = States.Attack;
            }
        }
        else if (!SeemPlayer && Chasing) {
            CurrentState = States.SeemPlayer;
            StartCoroutine(PlayerOutOfSight());
        }
        else if (!Chasing)
        {
            CurrentState = States.Wander;
            agent.stoppingDistance = 0;
            ViewLight.GetComponent<Light>().color = Color.green;
            agent.isStopped = false;
            //agent.updateRotation = true;
        }


    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        HandleStates();
        // stop sprite from moving or rotating 
        sprite.transform.position = new Vector3 (transform.position.x,1.5f, transform.position.z);
        sprite.transform.rotation = iniRot;
    }
    public virtual void MoveForward()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete&&(agent.remainingDistance > 0 && agent.remainingDistance < 1))
        {
            RandomMovePoint();
        }
        if (!attacking)
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
    public virtual void Attack() {
        //something

    }
    protected virtual void BasicAttack() { 
        
    }
    public virtual void ChasePlayer() {
        StoppingDistance = 5;
        agent.SetDestination(playerController.transform.position);
        agent.stoppingDistance = StoppingDistance;
        agent.isStopped = false;
    }
    IEnumerator PlayerOutOfSight() {
        yield return new WaitForSeconds(4.0f);
        if (!Viewcircle.GetComponent<ViewCircle>().visibleTargets.Contains(Viewcircle.GetComponent<ViewCircle>().Player))
        {
            Chasing = false;
        }
        StopCoroutine(PlayerOutOfSight());
    }
}
