using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingPuzzle : MonoBehaviour
{
    [SerializeField] private Text wordOutput;
    [SerializeField] private string password;
    private string currentTypedWord = "";

    // Update is called once per frame
    void Update()
    {
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

    private void CheckCorrectPassword()
    {
        if(currentTypedWord == password)
        {
            Debug.Log("thats Correct Password!!");
        }
    }
}
