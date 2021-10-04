using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HowToPlay;
    public GameObject Credits;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    void HideMenus()
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
    }

    public void ShowMainMenu()
    {
        HideMenus();
        MainMenu.SetActive(true);
    }

    public void ShowHowToPlay()
    {

        HideMenus();
        HowToPlay.SetActive(true);
    }

    public void ShowCredits()
    {

        HideMenus();
        Credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
