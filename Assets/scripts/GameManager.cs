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
    public GameObject menuHighScoreText;
    public GameObject menuCurrentScoreText;
    public Score currentScore;
    public bool mainMenu;
    public bool endMenu;
    public int highScore;
    public int currentScoreInt;

    void Start()
    {
        Load();
    }

    public void CompleteLevel()
    {
        currentScoreInt = currentScore.scoreInt;

        if (currentScoreInt > highScore)
        {
            highScore = currentScoreInt;
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
        if (mainMenu)
        {
            menuHighScoreText.GetComponent<Text>().text = highScore.ToString();
            if (endMenu)
            {
                currentScoreInt = data.thisScore;
                menuCurrentScoreText.GetComponent<Text>().text = currentScoreInt.ToString();
            }
        }
    }

    IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(1);
        completeLevelUI.GetComponent<LevelComplete>().LoadNextLevel();
    }
}
