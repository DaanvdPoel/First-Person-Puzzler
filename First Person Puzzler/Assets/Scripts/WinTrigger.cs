using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private CharacterController characterController;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerWon();
            characterController.enabled = false;
        }
    }
}
