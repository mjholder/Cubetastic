using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] highScores;
    public int[] thisScores;

    public PlayerData(GameManager player)
    {
        highScores = player.GetHighScores();
        thisScores = player.GetCurrentScores();
    }
}
