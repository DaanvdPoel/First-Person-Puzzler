using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    public bool powerEnabled;
    [SerializeField] private bool powerCellOne;
    [SerializeField] private bool powerCellTwo;
    [SerializeField] private bool powerCellThree;
    [Space]
    [SerializeField] private DoorTrigger powerDoorsOne;
    [SerializeField] private DoorTrigger powerDoorsTwo;
    [SerializeField] private DoorTrigger powerDoorsThree;

    [SerializeField] private GameObject wireSwitchOnePresent;
    [SerializeField] private GameObject wireSwitchTwoPresent;
    [SerializeField] private GameObject wireSwitchOnePast;
    [SerializeField] private GameObject wireSwitchTwoPast;
    [SerializeField] private GameObject interactText;

    public WireConnecting wireConnectingOne;
    public WireConnecting wireConnectingTwo;
    public TimeSwitch timeSwitching;


    // Start is called before the first frame update
    void Start()
    {
        wireSwitchOnePresent.SetActive(false);
        wireSwitchOnePast.SetActive(false);
        wireSwitchTwoPast.SetActive(false);
        wireSwitchTwoPresent.SetActive(false);
        powerEnabled = false;
     }

    // Update is called once per frame
    void Update()
    {

        if (powerEnabled == true)
        {
            if (powerCellOne && powerCellTwo && powerCellThree == false)
            {
                powerCellOne = true;
            }
        }

        if (wireConnectingOne.allWiresEnabled == true && wireConnectingTwo.allWiresEnabled == false)
        {
            powerDoorsOne.isDoorLocked = false;
            powerEnabled = true;
            powerCellOne = true;
            wireConnectingOne.WirePanelPresent.SetActive(false);
        }

        if(wireConnectingTwo.allWiresEnabled == true && wireConnectingTwo.allWiresEnabled == true)
        {
            powerDoorsTwo.isDoorLocked = false;
            powerCellTwo = true;
            wireConnectingTwo.WirePanelPresent.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PowerOne"))
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactText.SetActive(false);
                if (timeSwitching.pastActive == true)
                {
                    wireSwitchOnePast.SetActive(true);
                }
                if (timeSwitching.presentActive == true)
                {
                    wireSwitchOnePresent.SetActive(true);
                }
            }
        }
        if(other.gameObject.CompareTag("PowerTwo"))
        {
            interactText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                interactText.SetActive(false);
                if (timeSwitching.pastActive == true)
                {
                    wireSwitchTwoPast.SetActive(true);
                }
                if (timeSwitching.presentActive == true)
                {
                    wireSwitchTwoPresent.SetActive(true);
                }
            }
        }

        if(other.gameObject.CompareTag("PowerThree"))
        {
            interactText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                interactText.SetActive(false);
                powerCellThree = true;
                powerDoorsThree.isDoorLocked = false;
            }
        }
    }
}
