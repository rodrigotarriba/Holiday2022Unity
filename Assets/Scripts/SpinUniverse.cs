using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinUniverse : MonoBehaviour
{
    [SerializeField] float turnsPerMinuteZ;
    [SerializeField] float turnsPerMinuteY;
    private void Update()
    {
        transform.Rotate(0f, (360 * turnsPerMinuteY) / 60 * Time.deltaTime, (360*turnsPerMinuteZ)/60*Time.deltaTime);
    }

}
