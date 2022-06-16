using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isTyping = false;
    public bool isDead = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }
}
