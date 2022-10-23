using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkerAdjustment : MonoBehaviour, IPointerDownHandler
{
    public WorkerAssignment _workerAssignmentScript;


    GameObject FoodIncreaseButton;
    GameObject FoodDecreaseButton;
    GameObject WoodIncreaseButton;
    GameObject WoodDecreaseButton;
    GameObject RockIncreaseButton;
    GameObject RockDecreaseButton;

    private void Start()
    {
        FoodIncreaseButton = GameObject.FindWithTag("IncreaseFoodWorkerButton");
        FoodDecreaseButton = GameObject.FindWithTag("DecreaseFoodWorkerButton");
        WoodIncreaseButton = GameObject.FindWithTag("IncreaseWoodWorkerButton");
        WoodDecreaseButton = GameObject.FindWithTag("DecreaseWoodWorkerButton");
        RockIncreaseButton = GameObject.FindWithTag("IncreaseRockWorkerButton");
        RockDecreaseButton = GameObject.FindWithTag("DecreaseRockWorkerButton");
    }

    public void OnPointerDown(PointerEventData FoodIncreaseButton)
    {
        Debug.Log(this.gameObject.name + " Was asdfasdfasdfasd.");
        //_workerAssignmentScript.Writer();
    }

}
