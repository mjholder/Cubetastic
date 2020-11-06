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
        highScoreText.text = gameManager.GetHighScore().ToString();
        thisScoreText.text = gameManager.GetCurrentScore().ToString();
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
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
