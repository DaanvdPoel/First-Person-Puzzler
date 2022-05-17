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
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (present.activeInHierarchy == true)
            {
                past.SetActive(true);
                present.SetActive(false);
                Debug.Log("past active");
            }
            else if (present.activeInHierarchy == false)
            {
                past.SetActive(false);
                present.SetActive(true);
                Debug.Log("present active");
            }
        }
    }
}
