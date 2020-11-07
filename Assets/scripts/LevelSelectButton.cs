using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public int sceneIndex;
    public int levelIndex;

    public void SetLevel()
    {
        GameObject.FindObjectOfType<GameManager>().SetLevelToLoad(sceneIndex);
        GameObject.FindObjectOfType<GameManager>().SetLevelIndex(levelIndex);
    }
}
