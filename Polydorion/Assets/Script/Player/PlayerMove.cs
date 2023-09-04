using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movemenent")]
    public float movSped;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;



    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        MyInput();
    }

        private void FixedUpdate()
        {
            MovePly();
        }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    public void MovePly()
    {
        moveDirection =  orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * movSped * 10f, ForceMode.Force);
    }

}
