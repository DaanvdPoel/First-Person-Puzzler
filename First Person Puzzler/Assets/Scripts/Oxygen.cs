using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Oxygen : MonoBehaviour
{
    [SerializeField] GameObject OxygenHelmet;
    [SerializeField] GameObject InteractionText;
    [SerializeField] TextMeshProUGUI OxygenText;
    [SerializeField] CharacterController PlayerController;

    [SerializeField] private bool oxygenLevel;
    [SerializeField] private float oxygenLoweringTimer = 1;
    [SerializeField] private int oxygenAmmount = 100;

    // Update is called once per frame
    void FixedUpdate()
    {
        OxygenText.text = "Oxygen level: " + oxygenAmmount;

        if (oxygenLevel == false)
        {
            oxygenLoweringTimer = oxygenLoweringTimer -= Time.deltaTime;
            if (oxygenLoweringTimer <= 0)
            {
                oxygenAmmount = oxygenAmmount - 10;
                oxygenLoweringTimer = 1;
            }
        }
        if(oxygenLevel == true)
        {
            oxygenAmmount = 100;
        }

        if(oxygenAmmount <= 0)
        {
            GameManager.instance.PlayerDied();

            PlayerController.enabled = false;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Oxygen"))
        {
            InteractionText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                oxygenLevel = true;
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
