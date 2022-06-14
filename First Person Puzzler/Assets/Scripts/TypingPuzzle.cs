using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingPuzzle : MonoBehaviour
{
    [SerializeField] private Text wordOutput;
    [SerializeField] private string password;
    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private GameObject interactText;
    private string currentTypedWord = "";

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isTyping == true)
        {
            CheckInput();
        }

        if (interactText.active == true && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.isTyping = true;
            puzzleUI.active = true;
            interactText.active = false;
        }

        if(puzzleUI.active && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzle();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        wordOutput.text = currentTypedWord;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.Return) != true)
        {
            currentTypedWord = currentTypedWord + Input.inputString;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetText();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckCorrectPassword();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactText.active = true;

    }

    private void OnTriggerExit(Collider other)
    {
        interactText.active = false;
    }

    public void ExitPuzzle()
    {
        puzzleUI.active = false;
        GameManager.instance.isTyping = false;
        interactText.active = true;
        currentTypedWord = "";
    }

    public void CheckCorrectPassword()
    {
        if(currentTypedWord == password)
        {
            Debug.Log("thats Correct Password!!");
            interactText.active = false;
            puzzleUI.active = false;
            GameManager.instance.isTyping = false;
            Activate();
        }
        else
        {
            Debug.Log("thats Wrong Password!!");
        }
    }

    private void Activate()
    {
        CheckpointManager.instance.puzzlesComplete[0] = true;
    }

    public void ResetText()
    {
        currentTypedWord = "";
    }
}
