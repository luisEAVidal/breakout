using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelMenu : MonoBehaviour
{
    public void AdvanceLevel()
    {
        var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextLevel)
        {
            Debug.Log("Restoring time Scale");
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            LoadMainMenu(); //Remplace this for game ending scene
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
