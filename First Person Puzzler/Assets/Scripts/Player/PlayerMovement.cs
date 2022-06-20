using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool IsGrounded;
    private Vector3 lastPosition = new Vector3 (0, 0, 0);

    public AudioClip walkingSFX;
    public AudioSource CharacterSFX;

    void Update()
    {
        if (GameManager.instance.playerCantMove == false)
        {
            IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

            if (IsGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if(lastPosition != gameObject.transform.position)
            {
                CharacterSFX.playOnAwake(walkingSFX);
            }
        }
    }
}
