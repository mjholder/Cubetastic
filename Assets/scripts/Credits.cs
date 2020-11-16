using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public int levelIndex;
    public Text highScoreText;
    public Text thisScoreText;
    public GameManager gameManager;

    private void Start()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        levelIndex = gameManager.GetLevelIndex();
        highScoreText.text = gameManager.GetHighScores()[levelIndex].ToString();
        thisScoreText.text = gameManager.GetCurrentScores()[levelIndex].ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Retry();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(gameManager.GetLevelToLoad());
    }
}
