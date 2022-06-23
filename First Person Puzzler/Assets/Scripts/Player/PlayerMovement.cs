using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -0.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool IsGrounded;
    [SerializeField] private bool IsMoving = false;
    [SerializeField] private float stepTimer;

    public AudioClip movementSFX;
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

            if(controller.velocity.x < 0f || controller.velocity.x > 0f || controller.velocity.y < 0f || controller.velocity.y > 0f || controller.velocity.z < 0f || controller.velocity.z > 0f)
            {
                if(!IsMoving)
                {
                    StartCoroutine("PlaySound", stepTimer);
                }
            }
        }
    }

    IEnumerator PlaySound()
    {
        CharacterSFX.Play();

        IsMoving = true;
        yield return new WaitForSeconds(0.35f);
        IsMoving = false;

    }
}
