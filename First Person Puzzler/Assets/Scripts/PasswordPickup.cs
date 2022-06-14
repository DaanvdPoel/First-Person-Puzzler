using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPickup : MonoBehaviour
{
    [SerializeField] private GameObject passwordPickup;
    [SerializeField] private GameObject passwordTextObject;
    [SerializeField] private TextMeshProUGUI passwordText;

    private void Start()
    {
        passwordTextObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == passwordPickup && Input.GetKey(KeyCode.E))
        {
            passwordTextObject.SetActive(true);
            passwordText.text = "the password is...".ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        passwordTextObject.SetActive(false);
    }
}
