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
    [Space]
    [SerializeField] private GameObject powerLightingCellOneEnabled;
    [SerializeField] private GameObject powerLightingCellTwoEnabled;
    [SerializeField] private GameObject powerLightingCellThreeEnabled;
    [Space]
    [SerializeField] private GameObject powerLightingCellOneDisabled;
    [SerializeField] private GameObject powerLightingCellTwoDisabled;
    [SerializeField] private GameObject powerLightingCellThreeDisabled;

    [SerializeField] private GameObject wireSwitchOne;
    [SerializeField] private GameObject wireSwitchTwo;

    private PowerOnAnimated powerAnimated;
    public WireConnecting wireConnectingOne;
    public WireConnecting wireConnectingTwo;

    // Start is called before the first frame update
    void Start()
    {
        wireSwitchOne.SetActive(false);


        powerEnabled = false;
        powerLightingCellOneDisabled.SetActive(true);

        powerLightingCellOneEnabled.SetActive(false);

        powerAnimated = GetComponent<PowerOnAnimated>();
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

        if (wireConnectingOne.allWiresEnabled == true)
        {
            powerDoorsOne.isDoorLocked = false;

            powerEnabled = true;
            powerCellOne = true;
            powerCellTwo = false;
            powerCellThree = false;

            powerDoorsOne.isDoorLocked = false;
            powerDoorsTwo.isDoorLocked = true;
            powerDoorsThree.isDoorLocked = true;

            powerLightingCellOneEnabled.SetActive(true);
            powerLightingCellOneDisabled.SetActive(false);
            powerLightingCellTwoEnabled.SetActive(false);
            powerLightingCellTwoDisabled.SetActive(true);
            powerLightingCellThreeEnabled.SetActive(false);
            powerLightingCellThreeDisabled.SetActive(true);

            wireConnectingOne.WirePanel.SetActive(false);
        }

        if(wireConnectingTwo.allWiresEnabled == true)
        {
            powerCellOne = false;
            powerCellTwo = true;
            powerCellThree = false;

            powerDoorsOne.isDoorLocked = true;
            powerDoorsTwo.isDoorLocked = false;
            powerDoorsThree.isDoorLocked = true;

            powerLightingCellOneEnabled.SetActive(false);
            powerLightingCellOneDisabled.SetActive(true);
            powerLightingCellTwoEnabled.SetActive(true);
            powerLightingCellTwoDisabled.SetActive(false);
            powerLightingCellThreeEnabled.SetActive(false);
            powerLightingCellThreeDisabled.SetActive(true);

            wireConnectingTwo.WirePanel.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerEntered");
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(other.gameObject.CompareTag("PowerOne"))
            {
                wireSwitchOne.SetActive(true);
            }
            if(other.gameObject.CompareTag("PowerTwo"))
            {
                wireSwitchTwo.SetActive(true);
            }
            if(other.gameObject.CompareTag("PowerThree"))
            {
                powerCellOne = false;
                powerCellTwo = false;
                powerCellThree = true;

                powerDoorsOne.isDoorLocked = true;
                powerDoorsOne.isDoorLocked = true;
                powerDoorsOne.isDoorLocked = false;

                powerLightingCellOneEnabled.SetActive(false);
                powerLightingCellOneDisabled.SetActive(true);
                powerLightingCellTwoEnabled.SetActive(false);
                powerLightingCellTwoDisabled.SetActive(true);
                powerLightingCellThreeEnabled.SetActive(true);
                powerLightingCellThreeDisabled.SetActive(false);
            }
        }
    }
}
