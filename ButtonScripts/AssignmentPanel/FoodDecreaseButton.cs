using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodDecreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject FoodDecreaseButtoN;

    void Start()
    {
        FoodDecreaseButtoN = GameObject.FindWithTag("DecreaseFoodWorkerButton");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Food Worker decreased");
        _workerAssignmentScript.ChangeFoodWorkerPercentageDecreaser();
    }
}
