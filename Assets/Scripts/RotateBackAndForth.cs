using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackAndForth : MonoBehaviour
{
    [SerializeField] float rotationAngles;
    [SerializeField] float rotationSpeed;
    private float rotationOffset;
    float sinValue;

    private void Start()
    {
        rotationOffset = transform.rotation.eulerAngles.y;
    }


    // Update is called once per frame
    void Update()
    {
        sinValue = Mathf.Sin(Time.frameCount * rotationSpeed);
        transform.rotation = Quaternion.Euler(transform.rotation.x, (sinValue * rotationAngles) + rotationOffset, transform.rotation.z);
    }
}


