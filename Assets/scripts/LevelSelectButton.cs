using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public int sceneIndex;
    public int levelIndex;
    public Menu menu;

    public void SetLevel()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.SetLevelToLoad(sceneIndex);
        gameManager.SetLevelIndex(levelIndex);
        menu.SetHighScore(gameManager.GetHighScores()[levelIndex]);
    }
}
