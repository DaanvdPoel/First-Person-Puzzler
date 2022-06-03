using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    [SerializeField] private bool powerEnabled;
    [SerializeField] private bool powerCellOne;
    [SerializeField] private bool powerCellTwo;
    [SerializeField] private bool powerCellThree;


    // Start is called before the first frame update
    void Start()
    {
        powerEnabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(powerEnabled == true)
        {
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
            }
            if(other.gameObject.CompareTag("PowerTwo"))
            {
                powerCellOne = false;
                powerCellTwo = true;
                powerCellThree = false;
            }
            if(other.gameObject.CompareTag("PowerThree"))
            {
                powerCellOne = false;
                powerCellTwo = false;
                powerCellThree = true;
            }
        }
    }
}
