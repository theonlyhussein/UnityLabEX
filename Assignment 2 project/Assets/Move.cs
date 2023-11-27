using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Rigidbody rb;
    private float moveInterval = 5f;  // Time interval to move the object
    private float totalTime = 30f;    // Total time to move the object
    private float timer = 0f;         // Timer to keep track of elapsed time
    private float blockDistance = 1f; // Distance to move in one block

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Increment the timer each frame
        timer += Time.deltaTime;

        // Check if the total time has not elapsed
        if (timer <= totalTime)
        {
            // Check if it's time to move the object
            if (timer % moveInterval <= Time.deltaTime)
            {
                // Calculate the force needed to move the object forward
                Vector3 force = transform.forward * blockDistance / moveInterval;

                // Apply the force to the Rigidbody
                rb.AddForce(force, ForceMode.VelocityChange);
            }
        }
    }
}