using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController cch;

    public Transform cam;

    [Header("Movemenent")]
    public float movSped;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    public float smoothin = 0.1f;
    float smoothinVelo;

    Vector3 moveDirection;
    Rigidbody rb;
    
 //   public Transform cam;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        MyInput();
    }
/*
    private void FixedUpdate()
    {
        MovePly();
    }
*/
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothinVelo, smoothin); 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cch.Move(moveDir.normalized * movSped * Time.deltaTime);
        }

    }
/*
    public void MovePly()
    {
        moveDirection =  orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * movSped * 10f, ForceMode.Force);
    }
*/
    /*
    public void cthing()
    {
        moveDirection = Quaternion.AngleAxis(cam.rotation.eulerAngles.y, Vector3.up) * moveDirection;
        moveDirection.Normalize();
    }

    private void AppFocus(bool focus)
    {
        if(focus)
        {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        }
        else{
            Cursor.lockState =  CursorLockMode.None;
        }
    }*/
}
