using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKnipper : MonoBehaviour
{
    public bool toggle = false;
    public Vector2 cooldown, duration;
    float cooldownT, durationT;
    public GameObject toggledObject;
    bool startingState;
    // Start is called before the first frame update
    void Start()
    {
        startingState = toggledObject.active;
        ResetTimer();
    }
    
    void ResetTimer() => cooldownT = Random.Range(cooldown.x, cooldown.y);

    // Update is called once per frame
    void Update()
    {
        if ((cooldownT < Time.deltaTime) && (!(cooldownT == -21)))
        {
            //do the thing
            cooldownT = -21;
            
            if (toggle)
            {
                toggledObject.SetActive(!toggledObject.active);
                ResetTimer();
            }
            else
            {
                durationT = Random.Range(duration.x, duration.y);
                StartCoroutine(bruh());
            }
        }
        else
        {
            cooldownT -= Time.deltaTime;
        }
    }
    
    IEnumerator bruh()
    {
        toggledObject.SetActive(!startingState);
        yield return new WaitForSeconds(durationT);
        toggledObject.SetActive(startingState);
        ResetTimer();
        
    }
}
