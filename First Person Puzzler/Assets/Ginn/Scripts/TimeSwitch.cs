using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    public GameObject past;
    public GameObject present;


    void Start()
    {
        present.SetActive(true);
        past.SetActive(false);
    }

    void Update()
    {
        if(present.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                past.SetActive(true);
                present.SetActive(false);
                Debug.Log("past active");
            }
        }
        if(present.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                past.SetActive(false);
                present.SetActive(true);
                Debug.Log("present active");

            }
        }
    }
}
