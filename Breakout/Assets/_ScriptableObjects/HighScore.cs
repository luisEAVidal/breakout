using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "Tools/High Score", order = 0)]
public class HighScore : PersistantScore
{
    //public int currentScore = 0;
    public int highScore = 0;
}
