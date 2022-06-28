using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    [SerializeField] private GameObject KeycardPickup;
    [SerializeField] private GameObject AccessDeniedText;
    [SerializeField] private GameObject AccessGrantedText;
    [SerializeField] private GameObject InteractText;
    [SerializeField] private DoorTrigger doorEscapePod;

    [SerializeField] private bool accessGranted = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Keycard"))
        {
            InteractText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                InteractText.SetActive(false);
                accessGranted = true;
                KeycardPickup.SetActive(false);
                doorEscapePod.isDoorLocked = false;
            }
        }
        if(other.gameObject.CompareTag("EscapePodDoor"))
        {
            if(accessGranted == true)
            {
                AccessGrantedText.SetActive(true);
            }
            if(accessGranted == false)
            {
                AccessDeniedText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("EscapePodDoor"))
        {
            AccessDeniedText.SetActive(false);
            AccessGrantedText.SetActive(false);
            InteractText.SetActive(false);
        }

        if(other.gameObject.CompareTag("Keycard"))
        {
            InteractText.SetActive(false);
        }
    }
}
