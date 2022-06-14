using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimator : MonoBehaviour
{
    public ParticleSystem[] p;

    // Update is called once per frame
    public void DoThing()
    {
        foreach (ParticleSystem ps in p)
        {
            ps.Play();
        }
    }
}
