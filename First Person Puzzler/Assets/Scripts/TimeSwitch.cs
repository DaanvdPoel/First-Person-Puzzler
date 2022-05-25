using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    public GameObject past;
    public GameObject present;

    private Animator animator;
    public bool pastActive;
    public bool presentActive;
    public float TimeSwitchTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        present.SetActive(true);
        past.SetActive(false);

        presentActive = true;
        pastActive = false;

        animator.SetBool("SwitchPast", pastActive);
        animator.SetBool("SwitchPresent", presentActive);
        animator.SetFloat("SwitchTimer", TimeSwitchTimer);
    }

    void FixedUpdate()
    {
        animator.SetBool("SwitchPast", pastActive);
        animator.SetBool("SwitchPresent", presentActive);
        animator.SetFloat("SwitchTimer", TimeSwitchTimer);

        TimeSwitchTimer -= Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (TimeSwitchTimer <= 0f)
            {

                if (present.activeInHierarchy == true)
                {
                    past.SetActive(true);
                    present.SetActive(false);

                    pastActive = true;
                    presentActive = false;

                    Debug.Log("past active");
                    TimeSwitchTimer = 2f;
                }
                else if (present.activeInHierarchy == false)
                {
                    past.SetActive(false);
                    present.SetActive(true);

                    presentActive = true;
                    pastActive = false;

                    Debug.Log("present active");
                    TimeSwitchTimer = 2f;
                }
            }
        }
    }
}
