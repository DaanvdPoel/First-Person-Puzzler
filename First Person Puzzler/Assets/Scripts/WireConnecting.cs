using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireConnecting : MonoBehaviour
{
    public GameObject WirePanel;

    [SerializeField] private bool blueWire;
    [SerializeField] private bool redWire;
    [SerializeField] private bool yellowWire;
    [SerializeField] private bool greenWire;

    [SerializeField] private bool blueWirePressed;
    [SerializeField] private bool redWirePressed;
    [SerializeField] private bool yellowWirePressed;
    [SerializeField] private bool greenWirePressed;

    public bool allWiresEnabled;

    private void Start()
    {
        WirePanel.SetActive(false);
    }

    private void Update()
    {
        if(WirePanel.active == true)
        {
            GameManager.instance.playerCantMove = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(blueWire == true && redWire == true && yellowWire == true && greenWire == true)
        {
            GameManager.instance.playerCantMove = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            allWiresEnabled = true;
            WirePanel.SetActive(false);
        }
    }
    public void EnableBlueWire()
    {
        blueWirePressed = true;
        redWirePressed = false;
        greenWirePressed = false;
        yellowWirePressed = false;
    }
    public void EnableGreenWire()
    {
        greenWirePressed = true;
        blueWirePressed = false;
        redWirePressed = false;
        yellowWirePressed = false;
    }
    public void EnableRedWire()
    {
        redWirePressed = true;
        blueWirePressed = false;
        greenWirePressed = false;
        yellowWirePressed = false;

    }
    public void EnableYellowWire()
    {
        yellowWirePressed = true;
        blueWirePressed = false;
        greenWirePressed = false;
        redWirePressed = false;
    }
    public void CheckBlueWire()
    {
        if(blueWirePressed == true)
        {
            blueWire = true;
        }
        else
        {
            blueWirePressed = false;
        }
    }

    public void CheckGreenWire()
    {
        if(greenWirePressed == true)
        {
            greenWire = true;
        }
        else
        {
            greenWirePressed = false;
        }
    }

    public void CheckRedWire()
    {
        if(redWirePressed == true)
        {
            redWire = true;
        }
        else
        {
            redWirePressed = false;
        }
    }

    public void CheckYellowWire()
    {
        if(yellowWirePressed == true)
        {
            yellowWire = true; 
        }
        else
        {
            yellowWirePressed = false;
        }
    }
}
