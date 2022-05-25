using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingPuzzle : MonoBehaviour
{
    [SerializeField] private Text wordOutput;
    [SerializeField] private string password;
    [SerializeField] private GameObject UI;
    private bool canType = false;
    private string currentTypedWord = "";

    // Update is called once per frame
    void Update()
    {
        if(canType == true)
        CheckInput();
     
        UpdateUI();
    }

    void UpdateUI()
    {
        wordOutput.text = currentTypedWord;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            currentTypedWord = currentTypedWord + Input.inputString;
            CheckCorrectPassword();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentTypedWord = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.active = true;
        canType = true;
    }

    private void OnTriggerExit(Collider other)
    {
        UI.active = false;
        canType = false;
    }

    private void CheckCorrectPassword()
    {
        if(currentTypedWord == password)
        {
            Debug.Log("thats Correct Password!!");
        }
    }
}
