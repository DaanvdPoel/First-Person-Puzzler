using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOnAnimated : MonoBehaviour
{
    public Animator animator;

    public void EnablePower()
    {
        animator.SetTrigger("PowerOn");
    }
}
