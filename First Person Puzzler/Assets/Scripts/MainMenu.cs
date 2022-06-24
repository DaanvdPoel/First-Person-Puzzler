using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject CreditsMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject MainMenuButtons;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Main.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    private void Update()
    {
        if(SettingsMenu.active == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsMenu.SetActive(false);
            MainMenuButtons.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        MainMenuButtons.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        Main.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        Main.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
