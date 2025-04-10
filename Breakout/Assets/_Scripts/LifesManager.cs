using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

public class LifesManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> lifes;
    public GameObject ballPrefab;
    private Ball ballScript;
    public GameObject GameOverMenu;

    private void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        Time.timeScale = 1.0f;
        foreach (Transform child in children) {
            lifes.Add(child.gameObject);
            Debug.Log($"Adding Life: {lifes.Count}");
        }
    }

    public void LoseLife()
    {
        var objToDelete = lifes[lifes.Count - 1];
        Destroy(objToDelete);
        lifes.RemoveAt(lifes.Count - 1);
        if (lifes.Count <= 0) 
        {
            GameOverMenu.SetActive(true);
            return;
        }
        var ball = Instantiate(ballPrefab) as GameObject;
        ballScript = ball.GetComponent<Ball>();
        ballScript.DestroyedBall.AddListener(this.LoseLife);

        Debug.Log($"Remaining Lifes: {lifes.Count}");
    }
}
