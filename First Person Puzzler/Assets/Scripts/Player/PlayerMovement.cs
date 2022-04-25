using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float sprintSpeed = 15;
    [SerializeField] private float jumpForce = 5;

    [HideInInspector]
    public bool isRunning;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            isRunning = true;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isRunning == false)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * Time.deltaTime * movementSpeed);
        }
        else
        {
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * Time.deltaTime * sprintSpeed);
        }
    }
}
