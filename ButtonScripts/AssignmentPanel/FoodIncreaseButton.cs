using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodIncreaseButton : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject FoodIncreaseButtoN;
    
    void Start()
    {
        FoodIncreaseButtoN = GameObject.FindWithTag("IncreaseFoodWorkerButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData evendata)
    {
        Debug.Log("Food Worker indreased");
        _workerAssignmentScript.ChangeFoodWorkerPercentageIncreaser();
     
        
    }
}
