using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public bool isMoving;
    public float oxygen;

    public enum PlayerStates
    {
        Idle,
        Move,
    }
    PlayerStates state;

    // Start is called before the first frame update

    void Start()
    {
        state = PlayerStates.Move;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        HandleStates();
    }
    void HandleStates()
    {
        switch (state)
        {
            case PlayerStates.Idle:
                break;
            case PlayerStates.Move:
                Move();
                break;
            default:
                break;
        }
    }
    void InputHandle() {

    }

    void Move() {
        anim.SetInteger("PlayerState", 1);
        anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        anim.SetFloat("MoveZ", Input.GetAxis("Vertical"));
        Vector3 moveVector = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.Translate(moveVector);
        isMoving = (moveVector != Vector3.zero);
    }

}
