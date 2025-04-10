using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Transform transformHighScore, transformCurrentScore;
    public TMP_Text textHighScore, textCurrentScore;

    public HighScore highScoreScriptableObject;
    private long currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        transformHighScore = GameObject.Find("High_Score").transform;
        transformCurrentScore = GameObject.Find("Current_Score").transform;

        textHighScore = transformHighScore.GetComponent<TMP_Text>();
        textCurrentScore = transformCurrentScore.GetComponent<TMP_Text>();

        var scoreFileName = "HighScore Level " + SceneManager.GetActiveScene().buildIndex;

        try{ 
            highScoreScriptableObject.Load(scoreFileName); 
        }
        catch (FileNotFoundException){
            Debug.Log("High Score File not found, a default one will be created");
            highScoreScriptableObject.highScore = 0;
            highScoreScriptableObject.Save(scoreFileName);
        }
        Debug.Log("Starting High Score: " + highScoreScriptableObject.highScore);
        textHighScore.text = $"High Score: {highScoreScriptableObject.highScore}";

    }

    // Update is called once per frame
    void Update()
    {
        textCurrentScore.text = $"Score: {currentScore}";
        if (currentScore > highScoreScriptableObject.highScore) {
            highScoreScriptableObject.highScore = currentScore;
            textHighScore.text = $"High Score: {highScoreScriptableObject.highScore}";
            highScoreScriptableObject.Save();
        }
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
    }

    private void FixedUpdate()
    {
    }
}
