using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnecting : MonoBehaviour
{
    public GameObject WirePanelPresent;
    public GameObject WirePanelPast;
    [Space]
    public bool blueWire;
    public bool redWire;
    public bool yellowWire;
    public bool greenWire;
    [Space]
    [SerializeField] private bool blueWirePressed;
    [SerializeField] private bool redWirePressed;
    [SerializeField] private bool yellowWirePressed;
    [SerializeField] private bool greenWirePressed;
    [Space]
    [SerializeField] private bool puzzleComplete = false;
    [Space]
    [SerializeField] private GameObject correctBlueWire;
    [SerializeField] private GameObject incorrectBlueWire;
    [SerializeField] private GameObject correctRedWire;
    [SerializeField] private GameObject incorrectRedWire;
    [SerializeField] private GameObject correctYellowWire;
    [SerializeField] private GameObject incorrectYellowWire;
    [SerializeField] private GameObject correctGreenWire;
    [SerializeField] private GameObject incorrectGreenWire;
    [Space]
    [SerializeField] private GameObject BluePressed;
    [SerializeField] private GameObject RedPressed;
    [SerializeField] private GameObject YellowPressed;
    [SerializeField] private GameObject GreenPressed;
    public bool allWiresEnabled;


    private void Start()
    {
        WirePanelPresent.SetActive(false);
        WirePanelPast.SetActive(false);
    }

    private void Update()
    {
        if(WirePanelPast.active == true || WirePanelPresent.active == true)
        {
            GameManager.instance.playerCantMove = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.instance.playerCantMove = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                WirePanelPast.SetActive(false);
                WirePanelPresent.SetActive(false);
            }
        }

        if(blueWire == true && redWire == true && yellowWire == true && greenWire == true && puzzleComplete == false)
        {
            puzzleComplete = true;
            GameManager.instance.playerCantMove = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            allWiresEnabled = true;
            WirePanelPast.SetActive(false);
        }
    }
    public void EnableBlueWire()
    {
        blueWirePressed = true;
        redWirePressed = false;
        greenWirePressed = false;
        yellowWirePressed = false;

        BluePressed.SetActive(true);
        RedPressed.SetActive(false);
        YellowPressed.SetActive(false);
        GreenPressed.SetActive(false);

    }
    public void EnableGreenWire()
    {
        greenWirePressed = true;
        blueWirePressed = false;
        redWirePressed = false;
        yellowWirePressed = false;

        BluePressed.SetActive(false);
        RedPressed.SetActive(false);
        YellowPressed.SetActive(false);
        GreenPressed.SetActive(true);
    }
    public void EnableRedWire()
    {
        redWirePressed = true;
        blueWirePressed = false;
        greenWirePressed = false;
        yellowWirePressed = false;

        BluePressed.SetActive(false);
        RedPressed.SetActive(true);
        YellowPressed.SetActive(false);
        GreenPressed.SetActive(false);
    }
    public void EnableYellowWire()
    {
        yellowWirePressed = true;
        blueWirePressed = false;
        greenWirePressed = false;
        redWirePressed = false;

        BluePressed.SetActive(false);
        RedPressed.SetActive(false);
        YellowPressed.SetActive(true);
        GreenPressed.SetActive(false);
    }
    public void CheckBlueWire()
    {
        if(blueWirePressed == true)
        {
            blueWire = true;
            correctBlueWire.SetActive(true);
            incorrectBlueWire.SetActive(false);
        }
        else
        {
            blueWirePressed = false;
            incorrectBlueWire.SetActive(true);
        }
    }

    public void CheckGreenWire()
    {
        if(greenWirePressed == true)
        {
            greenWire = true;
            correctGreenWire.SetActive(true);
            incorrectGreenWire.SetActive(false);
        }
        else
        {
            greenWirePressed = false;
            incorrectGreenWire.SetActive(true);
        }
    }

    public void CheckRedWire()
    {
        if(redWirePressed == true)
        {
            redWire = true;
            correctRedWire.SetActive(true);
            incorrectRedWire.SetActive(false);
        }
        else
        {
            redWirePressed = false;
            incorrectRedWire.SetActive(true);
        }
    }

    public void CheckYellowWire()
    {
        if(yellowWirePressed == true)
        {
            yellowWire = true;
            correctYellowWire.SetActive(true);
            incorrectYellowWire.SetActive(false);
        }
        else
        {
            yellowWirePressed = false;
            incorrectYellowWire.SetActive(true);
        }
    }
}
