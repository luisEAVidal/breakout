using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksManager : MonoBehaviour
{
    public GameObject NextLevelMenu;
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            NextLevelMenu.SetActive(true);
        }
    }
}
