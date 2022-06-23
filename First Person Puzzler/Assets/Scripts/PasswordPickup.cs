using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordPickup : MonoBehaviour
{
    [SerializeField] private GameObject passwordPickup;
    [SerializeField] private GameObject passwordTextObject;
    [SerializeField] private TextMeshProUGUI passwordText;
    [SerializeField] private GameObject interactText;

    private void Start()
    {
        passwordTextObject.SetActive(false);
        interactText.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Password") && Input.GetKey(KeyCode.E))
        {
            interactText.SetActive(true);
            passwordTextObject.SetActive(true);
            passwordText.text = "incognition".ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);
        passwordTextObject.SetActive(false);
    }
}
