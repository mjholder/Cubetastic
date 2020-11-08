using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lastLevelPlayed;
    public int[] highScores;
    public int[] thisScores;

    public PlayerData(GameManager gameManager)
    {
        lastLevelPlayed = gameManager.GetLevelIndex();
        highScores = gameManager.GetHighScores();
        thisScores = gameManager.GetCurrentScores();
    }
}
