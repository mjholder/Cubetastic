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
    public Score score;
    private int highScore;
    private int currentScore;

    void Start()
    {
        Load();
    }

    public void CompleteLevel()
    {
        currentScore = score.scoreInt;

        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        Save();
        StartCoroutine(loadLevel());
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

    public void Save()
    {
        SaveSystem.SaveScore(this);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        highScore = data.highScore;
        currentScore = data.thisScore;
    }

    IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(1);
        completeLevelUI.GetComponent<LevelComplete>().LoadNextLevel();
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
