using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseboxGraphics : MonoBehaviour
{
    public bool debug;
    public GameObject[] wires, fixedwires;
    public Transform lever;
    public bool bluefixed, redfixed, yellowfixed, greenfixed, leverDown;

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            UpdateFusebox(bluefixed, redfixed, yellowfixed, greenfixed, leverDown);
        }
        
        float rt = lever.localEulerAngles.x;
        lever.localEulerAngles = new Vector3(Mathf.LerpAngle(rt, (leverDown)?80:-80, Time.deltaTime*8), 0, 0);
    }
    
    public void UpdateFusebox(bool a, bool b, bool c, bool d, bool e)
    {
        wires[0].SetActive(!a);
        fixedwires[0].SetActive(a);
        wires[1].SetActive(!b);
        fixedwires[1].SetActive(b);
        wires[2].SetActive(!c);
        fixedwires[2].SetActive(c);
        wires[3].SetActive(!d);
        fixedwires[3].SetActive(d);
        
        leverDown = e;
    }
}
