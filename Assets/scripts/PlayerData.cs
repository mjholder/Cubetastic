using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int highScore;
    public int thisScore;

    public PlayerData(GameManager player)
    {
        highScore = player.highScore;
        thisScore = player.currentScoreInt;
    }
}
