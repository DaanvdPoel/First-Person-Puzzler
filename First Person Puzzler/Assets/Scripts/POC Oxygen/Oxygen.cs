using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    [SerializeField] GameObject OxygenHelmet;

    [SerializeField] private bool oxygenLevel;
    [SerializeField] private float oxygenLoweringTimer = 1;
    [SerializeField] private int oxygenAmmount = 100;

    // Start is called before the first frame update
    void Start()
    {

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
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Oxygen") && Input.GetKeyDown(KeyCode.E))
        {
            oxygenLevel = true;
            OxygenHelmet.SetActive(false);
        }
    }
}
