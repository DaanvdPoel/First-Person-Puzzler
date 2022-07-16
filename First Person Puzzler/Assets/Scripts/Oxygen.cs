using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    [SerializeField] GameObject OxygenHelmet;
    [SerializeField] GameObject OxygenPast;
    [SerializeField] GameObject OxygenPresent;
    [SerializeField] GameObject InteractionText;
    [SerializeField] TextMeshProUGUI OxygenText;
    [SerializeField] CharacterController PlayerController;

    [SerializeField] private bool oxygenLevel;
    [SerializeField] private bool oxygenHelmetPickedUp;
    [SerializeField] private float oxygenLoweringTimer;
    [SerializeField] private float oxygenAmmount = 100;

    public TimeSwitch timeSwitching;

    private void Start()
    {
        OxygenPast.SetActive(false);
        OxygenPresent.SetActive(false);
        oxygenHelmetPickedUp = false;
    }

    void FixedUpdate()
    { 
        OxygenText.text = "Oxygen level: " + oxygenAmmount.ToString("0");

        //when the helmet has not been picked up your oxygen will deplete
        if(oxygenHelmetPickedUp == false || timeSwitching.presentActive == true)
        {
            oxygenLevel = false;
            if (oxygenLevel == false)
            {
                oxygenLoweringTimer = oxygenLoweringTimer -= Time.deltaTime;
                if (oxygenLoweringTimer <= 0)
                {
                    oxygenAmmount = oxygenAmmount - 0.5f;
                    oxygenLoweringTimer = 0.2f;
                }
            }

            //when oxygen <= 0 you will die
            if (oxygenAmmount <= 0)
            {
                GameManager.instance.PlayerDied();

                PlayerController.enabled = false;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        //when the helmet has been picked up and present is active your oxygen will continue to deplete
        //when the helmet has been picked up and past is active your oxygen will reset
        if (timeSwitching.pastActive == true && oxygenHelmetPickedUp == true)
        {
            OxygenPresent.SetActive(false);
            OxygenPast.SetActive(true);
            oxygenLevel = true;

            if(oxygenAmmount < 100)
            oxygenAmmount = oxygenAmmount + 0.5f;
        }

        if(timeSwitching.presentActive == true && oxygenHelmetPickedUp == true)
        {
            OxygenPresent.SetActive(true);
            OxygenPast.SetActive(false);
        }
    }

    //when interacting with the helmet it will be picked up
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Oxygen"))
        {
            InteractionText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                oxygenLevel = true;
                oxygenHelmetPickedUp = true;
                OxygenHelmet.SetActive(false);
                InteractionText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
    }
}
