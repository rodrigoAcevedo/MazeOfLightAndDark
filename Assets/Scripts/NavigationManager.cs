using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    const int MAIN_MENU = 0;
    const int IN_GAME = 1;
    const int END_GAME = 2;
    const int CREDITS = 3;
    public void StartGame()
    {
        SceneManager.LoadScene(IN_GAME);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(END_GAME);
    }

    public void ViewCredits()
    {
        SceneManager.LoadScene(CREDITS);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
