using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public bool isMoving;
    public float oxygen;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void InputHandle() {

    }

    void Move() {
        Vector3 moveVector = new Vector3 (Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(moveVector);
        isMoving = (moveVector != Vector3.zero);
    }

}
