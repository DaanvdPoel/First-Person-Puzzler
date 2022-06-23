using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject EndCutscene;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Present;
    [SerializeField] private GameObject Past;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject EndsceneCamera;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterController.enabled = false;
            UI.SetActive(false);
            Present.SetActive(false);
            Past.SetActive(false);
            Player.SetActive(false);
            EndsceneCamera.SetActive(true);
            EndCutscene.SetActive(true);
        }
    }

    private void Update()
    {
        if (EndCutscene.active == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
}
