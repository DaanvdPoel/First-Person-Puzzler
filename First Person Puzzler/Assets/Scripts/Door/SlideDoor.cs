using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    [SerializeField] private bool isLocked = false;
    [SerializeField] private Transform openPosition;
    [SerializeField] private Transform closedPosition;

    private bool isOpen = false;
    private float doorSpeed;

   // private Animator animator;
    private MeshRenderer meshRenderer;
    private Coroutine currentCoroutine;

    private void Start()
    {
       // animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //chanches the color of the door when its locked
        if (isLocked)
            meshRenderer.material.color = Color.red;
        else
            meshRenderer.material.color = Color.green;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //starts the door_opening animation if the player gets in the trigger
        if (other.gameObject.CompareTag("Player") && isLocked == false)
        {

        }
           // animator.SetBool("Open/Closed", true);
    }

    private void OnTriggerExit(Collider other)
    {
        //starts the door_closing animation of the player exits the trigger
        if (other.gameObject.CompareTag("Player") && isLocked == false)
        {

        }
         //   animator.SetBool("Open/Closed", false);
    }
}
