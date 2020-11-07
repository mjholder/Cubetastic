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
    private string gameVersion = "0.0.5";
    private int highScore;
    private int[] highScores;
    private int currentScore;
    private int[] currentScores;
    private int levelToLoad;

    [SerializeField]
    private int currentLevelIndex;

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
        highScores[currentLevelIndex] = highScore;
        currentScores[currentLevelIndex] = currentScore;
        SaveSystem.SaveScore(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadData(this);
        if (data != null)
        {
            highScores = data.highScores;
            currentScores = data.thisScores;
            highScore = highScores[currentLevelIndex];
        }
        else
        {
            highScores = new int[2];
            currentScores = new int[2];
        }
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

    public int[] GetHighScores()
    {
        return highScores;
    }

    public int[] GetCurrentScores()
    {
        return currentScores;
    }

    public void SetLevelToLoad(int level)
    {
        levelToLoad = level;
    }

    public int GetLevelToLoad()
    {
        return levelToLoad;
    }

    public void SetLevelIndex(int level)
    {
        currentLevelIndex = level;
    }

    public int GetLevelIndex()
    {
        return currentLevelIndex;
    }

    public string GetGameVersion()
    {
        return gameVersion;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
