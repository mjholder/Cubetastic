using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highScoreText;

    // depricated
    public void StartGmae()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // depricated
    public void Quit()
    {
        Application.Quit();
    }

    public void SetHighScore(int highScore)
    {
        highScoreText.text = highScore.ToString();
    }
}
