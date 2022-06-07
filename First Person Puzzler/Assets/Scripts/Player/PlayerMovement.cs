using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float sprintSpeed = 15;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float gravity = -9.81f;

    [HideInInspector]
    public bool isRunning;
    private CharacterController controller;
    private Vector3 velocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }

        if (GameManager.instance.isTyping == false)
        {
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

        //gravity
        velocity.y = velocity.y + gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("test");
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        velocity.y = 0;
    //        Debug.Log("test");
    //    }
    //}
}
