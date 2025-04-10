using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public void ShowPauseMenu ()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive (true);
        if (optionsMenu.activeInHierarchy) { 
            optionsMenu.SetActive (false);
        }
    }

    public void HidePauseMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ShowOptionMenu()
    {
        pauseMenu.SetActive(false );
        optionsMenu.SetActive(true);
    }
}
