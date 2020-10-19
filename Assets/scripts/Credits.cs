using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
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
