using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform transformHighScore, transformCurrentScore;
    public TMP_Text textHighScore, textCurrentScore;

    public HighScore highScoreScriptableObject;
    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        transformHighScore = GameObject.Find("High_Score").transform;
        transformCurrentScore = GameObject.Find("Current_Score").transform;

        textHighScore = transformHighScore.GetComponent<TMP_Text>();
        textCurrentScore = transformCurrentScore.GetComponent<TMP_Text>();

        //if(PlayerPrefs.HasKey("HighScore")) {
        //highScoreScriptableObject.highScore = PlayerPrefs.GetInt("HighScore");
        highScoreScriptableObject.Load();
            textHighScore.text = $"High Score: {highScoreScriptableObject.highScore}";
        //}

    }

    // Update is called once per frame
    void Update()
    {
        textCurrentScore.text = $"Score: {currentScore}";
        if (currentScore > highScoreScriptableObject.highScore) {
            highScoreScriptableObject.highScore = currentScore;
            textHighScore.text = $"High Score: {highScoreScriptableObject.highScore}";
            highScoreScriptableObject.Save();
            //PlayerPrefs.SetInt("HighScore", highScoreScriptableObject.highScore);
        }
    }

    private void FixedUpdate()
    {
        currentScore += 50;
    }
}
