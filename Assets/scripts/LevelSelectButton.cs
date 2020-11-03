using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public int levelIndex;

    public void SetLevel()
    {
        GameObject.FindObjectOfType<GameManager>().SetLevelToLoad(levelIndex);
    }
}
