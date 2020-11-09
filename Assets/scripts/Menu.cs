using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highScoreText;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider musicVolumeSlider;
    public InputField musicInputField;
    private float volume;

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

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SaveAndClose()
    {
        Save();
        CloseOptions();
    }

    public void ChangeVolumeSlider()
    {
        musicInputField.text = musicVolumeSlider.value.ToString();
    }

    public void ChangeVolumeInput()
    {
        musicVolumeSlider.value = musicInputField.text;
    }
}
