using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ShowOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
