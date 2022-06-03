using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CharacterController playerController;
    //[SerializeField] private TimerScript timerScript;

    //[0] typingPuzzle || [1] electricityFixing || [2] wireconnectingPuzzle || [3]
    [SerializeField] private bool[] puzzlesComplete = new bool[4];

    private void Start()
    {
        playerController = player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SaveCheckpoint();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadCheckpoint();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ResetCheckPoint();
        }
    }

    public void SaveCheckpoint()
    {
        ResetCheckPoint();
        Vector3 playerPosition = player.transform.position;

        PlayerPrefs.SetFloat("playerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerPosition.z);

        Debug.Log("save" + playerPosition);
      //    PlayerPrefs.SetFloat("timeRemaining", timerScript.timeRemaining);
    }

    public void LoadCheckpoint()
    {
        playerController.enabled = false;
        Vector3 newPlayerPosition;

        newPlayerPosition.x = PlayerPrefs.GetFloat("playerPositionX");
        newPlayerPosition.y = PlayerPrefs.GetFloat("playerPositionY");
        newPlayerPosition.z = PlayerPrefs.GetFloat("playerPositionZ");

        //  PlayerPrefs.GetFloat("timeRemaining", timerScript.timeRemaining);
        Debug.Log("load" + newPlayerPosition);
        player.transform.position = newPlayerPosition;
        playerController.enabled = true;
    }

    public void ResetCheckPoint()
    {
        Debug.Log("reset");

        PlayerPrefs.DeleteKey("playerPositionX");
        PlayerPrefs.DeleteKey("playerPositionY");
        PlayerPrefs.DeleteKey("playerPositionZ");

        //  PlayerPrefs.DeleteKey("timeRemaining");
    }
}
