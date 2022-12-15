using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using Dreamteck.Editor;

public class splinesManager : MonoBehaviour
{
    [SerializeField] Transform node_01;
    [SerializeField] float speedForHits;
    [SerializeField] float speedForNonHits;
    [SerializeField] float valueChangeForHits;
    [SerializeField] float valueChangeFOrNotHits;
    private Transform originalPosition;
    [SerializeField] Transform newPosition;
    private bool isBeingHit;


    [SerializeField] SplineComputer[] splineComputers;

    [SerializeField] Transform[] allNodes;
    private Transform[] allOriginalNodes;

    public void Start()
    {
        allOriginalNodes = allNodes;

    }

    private void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.A))
        {

            for (int i = 0; i < allNodes.Length; i++)
            {
                allNodes[i].localScale = new Vector3(1.5f, 1.5f, 1.5f);

                //allNodes[i].GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere*100f, ForceMode.Impulse);
            }


            //isBeingHit = true;
            //node_01.position = new Vector3(node_01.position.x, node_01.position.y + valueChangeForHits, node_01.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            for (int i = 0; i < allNodes.Length; i++)
            {
                allNodes[i].localScale = new Vector3(1f, 1f, 1f);

                //allNodes[i].GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere*100f, ForceMode.Impulse);
            }

            //foreach (var spline in splineComputers)
            //{
            //    spline.knotParametrization = 0f;
            //}

            //isBeingHit = false;
            //node_01.position = new Vector3(node_01.position.x, node_01.position.y - valueChangeFOrNotHits, node_01.position.z);
        }



        //if (isBeingHit)
        //{
        //    node_01.Translate(Vector3.Lerp(node_01.position, newPosition.position, 1f / speedForHits * Time.deltaTime));
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    isBeingHit = false;
        //}



        //if (!isBeingHit)
        //{
        //    node_01.Translate(Vector3.Lerp(node_01.position, originalPosition.position, 1f / speedForNonHits * Time.deltaTime));
        //}



    }




}
