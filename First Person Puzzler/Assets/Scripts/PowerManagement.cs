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

    private PowerOnAnimated powerAnimated;

    // Start is called before the first frame update
    void Start()
    {

        powerEnabled = false;
        powerLightingCellOneDisabled.SetActive(true);

        powerLightingCellOneEnabled.SetActive(false);

        powerAnimated = GetComponent<PowerOnAnimated>();
     }

    // Update is called once per frame
    void Update()
    {
        if(powerEnabled == true)
        {
            powerAnimated.EnablePower();

            if (powerCellOne && powerCellTwo && powerCellThree == false)
            {
                powerCellOne = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerEntered");
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(other.gameObject.CompareTag("PowerOne"))
            {
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
            }
            if(other.gameObject.CompareTag("PowerTwo"))
            {
                powerCellOne = false;
                powerCellTwo = true;
                powerCellThree = false;

                powerDoorsOne.isDoorLocked = true;
                powerDoorsOne.isDoorLocked = false;
                powerDoorsOne.isDoorLocked = true;

                powerLightingCellOneEnabled.SetActive(false);
                powerLightingCellOneDisabled.SetActive(true);
                powerLightingCellTwoEnabled.SetActive(true);
                powerLightingCellTwoDisabled.SetActive(false);
                powerLightingCellThreeEnabled.SetActive(false);
                powerLightingCellThreeDisabled.SetActive(true);
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
