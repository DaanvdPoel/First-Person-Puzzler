using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject CreditsMenu;

    private void Start()
    {
        Main.SetActive(true);
        CreditsMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {

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
}
