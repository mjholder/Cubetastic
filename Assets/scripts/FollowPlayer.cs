using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    public Vector3 offset;

    public bool lockX;
    public bool lockY;
    public bool lockZ;

    private Vector3 playerPos;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerPos = player.position;

            if (lockX)
            {
                playerPos.x = 0;
            }

            if (lockY)
            {
                playerPos.y = 0;
            }

            if (lockZ)
            {
                playerPos.z = 0;
            }

            transform.position = playerPos + offset;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
