using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] GameObject OxygenHelmet;
    [SerializeField] GameObject InteractionText;
    [SerializeField] GameObject YouAreDeadText;

    [SerializeField] private bool oxygenLevel;
    [SerializeField] private float oxygenLoweringTimer = 1;
    [SerializeField] private int oxygenAmmount = 100;

    private void Start()
    {
        InteractionText.SetActive(false);
        YouAreDeadText.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oxygenLevel == false)
        {
            oxygenLoweringTimer = oxygenLoweringTimer -= Time.deltaTime;
            if (oxygenLoweringTimer <= 0)
            {
                oxygenAmmount = oxygenAmmount - 10;
                oxygenLoweringTimer = 1;
            }
        }

        if(oxygenAmmount <= 0)
        {
            YouAreDeadText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        InteractionText.SetActive(true);
        if(other.CompareTag("Oxygen") && Input.GetKeyDown(KeyCode.E))
        {
            oxygenLevel = true;
            OxygenHelmet.SetActive(false);
            InteractionText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
    }
}
