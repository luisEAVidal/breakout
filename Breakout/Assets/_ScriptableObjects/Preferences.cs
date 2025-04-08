using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Preferences", menuName = "Tools/Preferences", order = 1)]

public class Preferences : PersistantObject
{

    public float currentBallSpeed = 20.0f;
    public Difficulty currentDifficulty = Difficulty.Normal;
    public enum Difficulty
    {
        Easy = 0,
        Normal = 1,
        Hard = 2
    }


    public void UpdateSpeed(float speed)
    {
        currentBallSpeed = speed;
    }

    public void UpdateDifficulty(int difficulty) 
    { 
        currentDifficulty = (Difficulty)difficulty;
    }
}
