using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    public GameObject past;
    public GameObject present;

    [SerializeField] GameObject pastText;
    [SerializeField] GameObject presentText;

    private Animator animator;
    public bool pastActive;
    public bool presentActive;
    public float timeSwitchTimer;
    public float showHint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        GiveTimeSwitchTextHint();

        present.SetActive(true);
        past.SetActive(false);

        presentActive = true;
        pastActive = false;

        pastText.SetActive(false);
        presentText.SetActive(false);

        animator.SetBool("SwitchPast", pastActive);
        animator.SetBool("SwitchPresent", presentActive);
        animator.SetFloat("SwitchTimer", timeSwitchTimer);

    }

    void FixedUpdate()
    {
        animator.SetBool("SwitchPast", pastActive);
        animator.SetBool("SwitchPresent", presentActive);
        animator.SetFloat("SwitchTimer", timeSwitchTimer);

        timeSwitchTimer -= Time.deltaTime;
        showHint = showHint += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.P))
        {
            pastText.SetActive(false);
            presentText.SetActive(false);
            if (timeSwitchTimer < 0f)
            {
                if (present.activeInHierarchy == true)
                {
                    past.SetActive(true);
                    present.SetActive(false);

                    pastActive = true;
                    presentActive = false;

                    timeSwitchTimer = 2f;
                }
                else if (present.activeInHierarchy == false)
                {
                    past.SetActive(false);
                    present.SetActive(true);

                    presentActive = true;
                    pastActive = false;

                    timeSwitchTimer = 2f;
                }
            }
        }
        GiveTimeSwitchTextHint();
    }

    private void GiveTimeSwitchTextHint()
    {
        if(showHint > 2f)
        {
            if (presentActive == true)
            {
                pastText.SetActive(true);
            }
            if (pastActive == true)
            {
                presentText.SetActive(true);
            }
        }
    }
}
