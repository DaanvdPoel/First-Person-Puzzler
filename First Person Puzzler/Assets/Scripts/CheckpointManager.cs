using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private CharacterController playerController;

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject player;
    //[SerializeField] private Timer timer;

    //[0] typingPuzzle || [1] electricityFixing || [2] wireconnectingPuzzle || [3]
     public bool[] puzzlesComplete = new bool[4];


    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

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

        //PlayerPrefs.SetFloat("timeRemaining", timer.timeRemaining);

        Debug.Log("save" + playerPosition);
    }

    public void LoadCheckpoint()
    {
        playerController.enabled = false;
        Vector3 newPlayerPosition;

        newPlayerPosition.x = PlayerPrefs.GetFloat("playerPositionX");
        newPlayerPosition.y = PlayerPrefs.GetFloat("playerPositionY");
        newPlayerPosition.z = PlayerPrefs.GetFloat("playerPositionZ");

        if (newPlayerPosition != new Vector3(0,0,0))
        {
            //timer.timeRemaining = PlayerPrefs.GetFloat("timeRemaining", timer.timeRemaining);
            player.transform.position = newPlayerPosition;
            playerController.enabled = true;
        }
        else
        {
            //timer.timeRemaining = PlayerPrefs.GetFloat("timeRemaining", timer.timeRemaining);
            player.transform.position = spawnLocation.position;
            playerController.enabled = true;
        }

            Debug.Log("load" + newPlayerPosition);
    }

    public void ResetCheckPoint()
    {
        Debug.Log("reset");
        PlayerPrefs.DeleteKey("playerPositionX");
        PlayerPrefs.DeleteKey("playerPositionY");
        PlayerPrefs.DeleteKey("playerPositionZ");

        PlayerPrefs.DeleteKey("timeRemaining");
    }
}
