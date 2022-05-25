using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagement : MonoBehaviour
{
    private bool powerEnabled;
    private bool powerCellOne;
    private bool powerCellTwo;
    private bool powerCellThree;


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
}
