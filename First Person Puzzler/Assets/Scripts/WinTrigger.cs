using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactText.active = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.instance.PlayerWon();
            }
        }
    }
}
