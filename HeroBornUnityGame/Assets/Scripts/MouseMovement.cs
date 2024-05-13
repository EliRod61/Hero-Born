using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Add conponent character controller and then add to script in inspector
public class MouseMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    private Vector3 camRotation;
    private Transform cam;
    private Vector3 moveDirection;

    [Range(-45, -15)]
    public int minAngle = -30;
    [Range(30, 80)]
    public int maxAngle = 45;
    [Range(50, 500)]
    public int sensitivity = 1000;

    private void Awake()
    {
        cam = Camera.main.transform;
    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up * sensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));

        camRotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);

        cam.localEulerAngles = camRotation;
    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(horizontalMove, 0, verticalMove);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        //moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
    void Update()
    {
        Move();
        Rotate();
    }
}
