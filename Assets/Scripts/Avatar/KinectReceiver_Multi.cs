using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectReceiver_Multi : MonoBehaviour
{
    [SerializeField] OSC oscManager;

    //From Touchdesigner but Hard coded
    [SerializeField] int MaxNumberOfPlayers;
    [SerializeField] int NumberOfJointsTracked;

    //data from touchdesigner directly
    [SerializeField] int CurrentKinectMoving;

    //computation of the lenght of data arrays
    private int LengthOfDataArrays;

    //Pending - rtcpending
    [SerializeField] Vector3 posOffsetPerKinect;


    //OperatorsToModifyTheList
    List<float> emptyJoint;
    List<List<float>> emptyPlayer;
    List<List<List<float>>> emptyKinect;
    List<List<List<List<float>>>> allKinects;

    //ReferenceToAllTheEmitersFromTheGame
    [SerializeField] private Transform[] bigEmittersPool;


    //Import node animator
    [SerializeField] Animator[] nodesAnimators;



    // Start is called before the first frame update
    public void Start()
    {
        //Initializing OSC handler
        ///This custom function is enabled everytime the script receives an OSC message
        oscManager.SetAllMessageHandler(OnReceiveOSCJoints);

        emptyJoint = new List<float>();
        emptyPlayer = new List<List<float>>();
        emptyKinect = new List<List<List<float>>>();
        allKinects = new List<List<List<List<float>>>>();


        //MakeSure our measures object has the appropiate measurements
        for (int i = 0; i < 3; i++)
        {
            emptyJoint.Add(0f);
        }

        for (int i = 0; i < NumberOfJointsTracked; i++)
        {
            emptyPlayer.Add(emptyJoint);
        }

        for (int i = 0; i < MaxNumberOfPlayers; i++)
        {
            emptyKinect.Add(emptyPlayer);
        }

        for (int i = 0; i < 4; i++)
        {
            allKinects.Add(emptyKinect);
        }

        LengthOfDataArrays = 64;
    }

    public void Update()
    {
        //Test animations being triggered
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(node_01Animator.playbackTime);
            //This effectively plays it from 0 every time is triggered, when not identified as a loop
            nodesAnimators[4].SetTrigger("Restart");
            nodesAnimators[5].SetTrigger("Restart");

        }

    }



    public void OnReceiveOSCJoints(OscMessage message)
    {


        switch (message.address)
        {
            case "/audio":
                if (message.GetFloat(0) > 0)
                {
                    nodesAnimators[4].SetTrigger("Restart");
                    nodesAnimators[5].SetTrigger("Restart");
                    nodesAnimators[6].SetTrigger("Restart");
                    nodesAnimators[7].SetTrigger("Restart");
                    nodesAnimators[1].SetTrigger("Restart");
                    nodesAnimators[2].SetTrigger("Restart");
                    nodesAnimators[3].SetTrigger("Restart");
                }
                
                break;

            case "/frame":
                CurrentKinectMoving = (int)message.GetFloat(0);
                break;

            case "/tx":
                for (int i = 0; i < LengthOfDataArrays; i++)
                {
                    bigEmittersPool[i].localPosition = new Vector3(message.GetFloat(i), bigEmittersPool[i].localPosition.y, bigEmittersPool[i].localPosition.z);
                    //allKinects[CurrentKinectMoving][i % MaxNumberOfPlayers][Mathf.FloorToInt(i / MaxNumberOfPlayers)][0] = message.GetFloat(i);
                }
                break;

            case "/ty":
                for (int i = 0; i < LengthOfDataArrays; i++)
                {
                    bigEmittersPool[i].localPosition = new Vector3(bigEmittersPool[i].localPosition.x, message.GetFloat(i), bigEmittersPool[i].localPosition.z);
                    //allKinects[CurrentKinectMoving][i % MaxNumberOfPlayers][Mathf.FloorToInt(i / MaxNumberOfPlayers)][1] = message.GetFloat(i);
                }
                break;

            case "/tz":
                for (int i = 0; i < LengthOfDataArrays; i++)
                {
                    bigEmittersPool[i].localPosition = new Vector3(bigEmittersPool[i].localPosition.x, bigEmittersPool[i].localPosition.y, message.GetFloat(i));
                    //allKinects[CurrentKinectMoving][i % MaxNumberOfPlayers][Mathf.FloorToInt(i / MaxNumberOfPlayers)][2] = message.GetFloat(i);
                }
                break;

        }

    }


    public void LateUpdate()
    {


    }

}
