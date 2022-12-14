using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSun : MonoBehaviour
{
    // Rotation speed along the Y axis (in degrees per second)
    public float yTurnsPerMinute = 1;

    // Range of rotation along the X axis (in degrees)
    public float xRotationRange = 30f;

    // Current rotation along the X axis
    public float xRotationSpeed;
    private float xRotation = 0f;

    void Update()
    {
        // Rotate the game object along the Y axis
        transform.Rotate(0f, ((360*yTurnsPerMinute)/60)*Time.deltaTime, 0f);

        // Randomly rotate along the X axis
        xRotation = Random.Range(-xRotationRange, xRotationRange);
        transform.Rotate(xRotation * Time.deltaTime * xRotationSpeed, 0f, 0f);
    }
}
