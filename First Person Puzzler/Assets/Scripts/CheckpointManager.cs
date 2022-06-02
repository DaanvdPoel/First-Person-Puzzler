using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private TimerScript timerScript;

    //[0] typingPuzzle || [1] electricityFixing || [2] wireconnectingPuzzle || [3]
    [SerializeField] private bool[] puzzlesComplete = new bool[4];

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public void SaveCheckpoint()
    {
        PlayerPrefs.SetFloat("playerPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("playerPositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("playerPositionZ", player.transform.position.z);

      //    PlayerPrefs.SetFloat("timeRemaining", timerScript.timeRemaining);
    }

    public void LoadCheckpoint()
    {
        PlayerPrefs.GetFloat("playerPositionX", player.transform.position.x);
        PlayerPrefs.GetFloat("playerPositionY", player.transform.position.y);
        PlayerPrefs.GetFloat("playerPositionZ", player.transform.position.z);

        //  PlayerPrefs.GetFloat("timeRemaining", timerScript.timeRemaining);
    }

    public void ResetCheckPoint()
    {
        PlayerPrefs.DeleteKey("playerPositionX");
        PlayerPrefs.DeleteKey("playerPositionY");
        PlayerPrefs.DeleteKey("playerPositionZ");

        //  PlayerPrefs.DeleteKey("timeRemaining");
    }
}
