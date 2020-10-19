using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;
    public int offset;
    public Obstacle[] obstacles;
    
    private float cooldown = 0.0f;
    private Vector3 lastPos;
    private float distanceTraveled;

    void Update()
    {
        if (lastPos == null)
        {
            lastPos = transform.position;
        }

        distanceTraveled += transform.position.z - lastPos.z;
        lastPos = transform.position;
        transform.position = new Vector3(0, 0, player.position.z + offset);

        if (distanceTraveled >= cooldown)
        {
            cooldown = PlaceObstacle();
            distanceTraveled = 0.0f;
        }
    }

    float PlaceObstacle()
    {
        int obsIndex = Random.Range(0, obstacles.Length);
        Obstacle obstacle = obstacles[obsIndex];
        int obsX = Random.Range(obstacle.placeMin, obstacle.placeMax + 1);
        Vector3 obsPos = new Vector3(obsX, 0, transform.position.z);

        Instantiate(obstacle.pattern, obsPos, Quaternion.identity);
        
        return obstacle.cooldown;
    }
}
