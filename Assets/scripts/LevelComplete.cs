using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadEndScreen()
    {
        SceneManager.LoadScene(4);
    }
}
