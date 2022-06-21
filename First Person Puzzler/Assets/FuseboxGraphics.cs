using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseboxGraphics : MonoBehaviour
{
    public bool debug;
    public GameObject[] wires, fixedwires;
    public bool bluefixed, redfixed, yellowfixed, greenfixed;

    // Update is called once per frame
    void Update()
    {
        if (debug)
        {
            UpdateFusebox(bluefixed, redfixed, yellowfixed, greenfixed);
        }
    }
    
    public void UpdateFusebox(bool a, bool b, bool c, bool d)
    {
        wires[0].SetActive(!a);
        fixedwires[0].SetActive(a);
        wires[1].SetActive(!b);
        fixedwires[1].SetActive(b);
        wires[2].SetActive(!c);
        fixedwires[2].SetActive(c);
        wires[3].SetActive(!d);
        fixedwires[3].SetActive(d);
    }
}
