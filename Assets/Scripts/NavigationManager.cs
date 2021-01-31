using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    const int IN_GAME = 1;
    const int END_GAME = 2;
    public void StartGame()
    {
        SceneManager.LoadScene(IN_GAME);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(END_GAME);
    }
}
