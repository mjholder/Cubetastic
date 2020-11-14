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

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("MusicVolume");
    }

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
        musicVolumeSlider.value = volume;
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", (float)volume);
    }

    public void SaveAndClose()
    {
        Save();
        CloseOptions();
    }

    public void OnChangeVolumeSlider()
    {
        volume = musicVolumeSlider.value;
        musicInputField.text = volume.ToString();
    }

    public void OnChangeVolumeInput()
    {
        volume = Mathf.Clamp(Helper.StringToInt(musicInputField.text), 0, 100);
        musicVolumeSlider.value = volume;
    }
}
