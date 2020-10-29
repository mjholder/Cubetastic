using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleClearer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Obstacle")
        {
            Destroy(collision.gameObject.transform.root.gameObject);
        }
    }
}
