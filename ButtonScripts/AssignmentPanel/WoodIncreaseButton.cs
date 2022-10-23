using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WoodIncreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject WoodIncreaseButtoN;
    
    void Start()
    {
        WoodIncreaseButtoN = GameObject.FindWithTag("IncreaseWoodWorkerButton");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Wood Worker increased");
        _workerAssignmentScript.ChangeWoodWorkerPercentageIncreaser();
        
    }
}
