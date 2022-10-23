using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RockDecreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject RockDecreaseButtoN;

    void Start()
    {
        RockDecreaseButtoN = GameObject.FindWithTag("DecreaseRockWorkerButton");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Rock Worker decreased");
        _workerAssignmentScript.ChangeRockWorkerPercentageDecreaser();
    }
}
