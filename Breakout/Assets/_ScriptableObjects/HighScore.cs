using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "Tools/High Score", order = 0)]
public class HighScore : PersistantObject
{
    //public int currentScore = 0;
    public long highScore = 0;
}
