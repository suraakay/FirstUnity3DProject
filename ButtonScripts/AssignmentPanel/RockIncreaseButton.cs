using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RockIncreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject RockIncreaseButtoN;
    
    void Start()
    {
        RockIncreaseButtoN = GameObject.FindWithTag("IncreaseRockWorkerButton");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Rock Worker increased");
        _workerAssignmentScript.ChangeRockWorkerPercentageIncreaser();
    }
}
