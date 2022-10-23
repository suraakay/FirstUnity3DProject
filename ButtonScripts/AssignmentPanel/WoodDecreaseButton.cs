using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WoodDecreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject WoodDecreaseButtoN;

    void Start()
    {
        WoodDecreaseButtoN = GameObject.FindWithTag("IncreaseFoodWorkerButton");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Wood Worker decreased");
        _workerAssignmentScript.ChangeWoodWorkerPercentageDecreaser();
    }
}
