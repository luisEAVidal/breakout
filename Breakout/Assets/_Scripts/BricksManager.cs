using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BricksManager : MonoBehaviour
{
    public GameObject NextLevelMenu;
    public int BallDamage = 2;
    public Preferences PreferencesScriptableObject;

    private void LoadDamageValue()
    {
        try
        {
            PreferencesScriptableObject.Load();
            var difficulty = PreferencesScriptableObject.currentDifficulty;
            switch (difficulty)
            {
                case Preferences.Difficulty.Easy:
                    BallDamage = 3; break;
                case Preferences.Difficulty.Normal:
                    BallDamage = 2; break;
                case Preferences.Difficulty.Hard:
                    BallDamage = 1; break;
            }
        }
        catch (FileNotFoundException)
        {
            Debug.Log("Preferences File not found, a default one will be created");
            PreferencesScriptableObject.currentDifficulty = Preferences.Difficulty.Normal;
            PreferencesScriptableObject.Save();
        }

        Debug.Log("Damage will be " + BallDamage);

    }
    private void OnEnable()
    {
        LoadDamageValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            Time.timeScale = 0;
            NextLevelMenu.SetActive(true);
        }
    }
}
