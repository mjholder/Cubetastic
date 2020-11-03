using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public Score score; // Score is attached to the score display in game
    private int highScore;
    private int currentScore;
    private int levelToLoad;

    void Start()
    {
        LoadData();
    }

    public void CompleteLevel()
    {
        currentScore = score.scoreInt;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        SaveData();
        StartCoroutine(LoadEnd());
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay); // Calls function with delay in seconds
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveData()
    {
        SaveSystem.SaveScore(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadData();
        highScore = data.highScore;
        currentScore = data.thisScore;
    }

    public void LoadLevel()
    {
        if (levelToLoad != 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    IEnumerator LoadEnd()
    {
        yield return new WaitForSeconds(1);
        completeLevelUI.GetComponent<LevelComplete>().LoadEndScreen();
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetLevelToLoad(int level)
    {
        levelToLoad = level;
    }

    public int GetLevelToLoad()
    {
        return levelToLoad;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
