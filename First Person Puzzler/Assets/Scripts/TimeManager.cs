using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject _past;
    [SerializeField] private GameObject _pressent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if(_past.active == true)
            {
                _past.active = false;
                _pressent.active = true;
            }
            else if (_pressent.active == true)
            {
                _past.active = true;
                _pressent.active = false;
            }

        }
    }
}
