using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool playerCantMove = false;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    public void PlayerWon()
    {
        playerCantMove = true;
        winScreen.active = true;
        CheckpointManager.instance.ResetCheckPoint();
    }

    public void PlayerDied()
    {
        deathScreen.active = true;
        playerCantMove = true;
    }
}
