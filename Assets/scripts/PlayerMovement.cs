using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public int distance;

    public bool useAccelartion;
    public float accelaration;

    // FixedUpdate should be used over Update for physics
    void FixedUpdate()
    {
        distance = (int)transform.position.z;

        if (useAccelartion)
        {
            rb.AddForce(0, 0, accelaration * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Time.deltaTime normalizes based on FPS. Time between frames.
        }

        // it is much better to check for input in Update(). 
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            //FindObjectOfType<GameManager>().EndGame(); FOR NORMAL MODE
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }
}
