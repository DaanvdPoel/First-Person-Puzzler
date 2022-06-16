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
    [SerializeField] private DoorTrigger door; //if the puzzle is solved this door wil open

    [HideInInspector]
    public bool puzzleComplete = false;
    private string currentTypedWord = "";

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isTyping == true)
        {
            CheckInput();
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

    private void OnTriggerStay(Collider other)
    {
        if (interactText.active == true && Input.GetKeyDown(KeyCode.E) && puzzleComplete == false && other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.isTyping = true;
            puzzleUI.active = true;
            interactText.active = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && puzzleComplete == false)
        {
            puzzleComplete = CheckpointManager.instance.puzzlesComplete[0];
            interactText.active = true;
        }else if(puzzleComplete == true)
        {
            Activate();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactText.active = false;
        }
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
        door.isDoorLocked = false;
    }

    public void ResetText()
    {
        currentTypedWord = "";
    }
}
