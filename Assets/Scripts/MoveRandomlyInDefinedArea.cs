using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomlyInDefinedArea : MonoBehaviour
{
    //Define the constraints to be used in space
    [SerializeField] float movementRadius;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 savedPosition;


    private void Start()
    {
        savedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, (Random.insideUnitSphere * movementRadius) + savedPosition, movementSpeed * Time.deltaTime);




    }
}
