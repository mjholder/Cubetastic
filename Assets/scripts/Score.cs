using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Transform player;
    public Text scoreText;
    public int scoreInt;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            scoreInt = (int)player.position.z;
            scoreText.text = player.position.z.ToString("0"); // "0" in ToString() truncates decimal places
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
