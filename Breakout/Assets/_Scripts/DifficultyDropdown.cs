using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyDropdown : MonoBehaviour
{
    public Preferences preferencesScriptableObject;
    private TMP_Dropdown diffculty;
    // Start is called before the first frame update
    void Start()
    {
        diffculty = this.GetComponent<TMP_Dropdown>();
        diffculty.value = (int)preferencesScriptableObject.currentDifficulty;
        diffculty.onValueChanged.AddListener(delegate { preferencesScriptableObject.UpdateDifficulty(diffculty.value); });
    }

}